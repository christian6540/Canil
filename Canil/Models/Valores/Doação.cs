using Canil.Areas.Identity.Data;
using Canil.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Canil.Models.Valores
{
    public class Doação
    {
        public int Id { get; set; }
        public int CanilUserId { get; set; }
        public CanilUser CanilUser { get; set; }
        public long Valor { get; set; }
    }
}