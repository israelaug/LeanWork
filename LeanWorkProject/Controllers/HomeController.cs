using System;
using Microsoft.AspNetCore.Mvc;
using LeanWorkProject.Models;

namespace LeanWorkProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Card()
        {
            ViewData["Message"] = "Validador de Cartão de crédito";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Descrição";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contatos";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier ?? "error" });
        }
    }
}
