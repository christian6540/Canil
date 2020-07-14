using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canil.Areas.Identity.Data;
using Canil.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Canil.Models.Doações
{
    public class CriarDoação
    {
        private CanilContext _context;

        public CriarDoação(CanilContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            var Doação = new Doação
            {
                Valor = request.Valor,
            };

            _context.Doação.Add(Doação);

            await _context.SaveChangesAsync();

            return new Response
            {
                Id = Doação.Id,
                Valor = Doação.Valor,
            };
        }

        public class Request
        {
            public decimal Valor { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public decimal Valor { get; set; }
        }
    }
}