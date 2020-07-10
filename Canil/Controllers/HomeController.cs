using Canil.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Canil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult login()
        {
            return RedirectToAction("Index");
        }

        public IActionResult caes()
        {
            return View();
        }

        public IActionResult adote()
        {
            return View();
        }

        public IActionResult doaçoes()
        {
            return View();
        }

        public IActionResult loja()
        {
            return View();
        }

        public IActionResult canil()
        {
            return View();
        }

        public IActionResult saude()
        {
            return View();
        }

        public IActionResult treino()
        {
            return View();
        }

        public IActionResult atividades()
        {
            return View();
        }

        //[Authorize]
        public IActionResult adicionar_cao()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> adicionar_cao(IFormFile file)
        {
            await UploadFile(file);
            TempData["msg"] = "File Uploaded";
            return View();
        }

        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            bool iscopied = false;
            try
            {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));
                        using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                        {
                            await file.CopyToAsync(filestream);
                        }
                        iscopied = true;
                    }
                    else
                    {
                        iscopied = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return iscopied;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}