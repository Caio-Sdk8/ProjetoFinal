using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;

namespace InstaDev.Controllers
{
    public class HomeController : Controller
    {
        Usuario usuarioModel = new Usuario();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("Editar")]
        public IActionResult Editar(IFormCollection form){
            Usuario u = new Usuario();
            u.ImagemUsuario = form["ImagemUsuario"];
            u.Nome = form["Nome"];
            u.Username = form["Username"];
            u.email = form["email"];

            usuarioModel.alterar(u);
            return LocalRedirect("");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
