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

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();
            novoUsuario.email = form["email"];
            novoUsuario.Nome = form["Nome"];
            novoUsuario.Username = form["Username"];
            novoUsuario.senha = form["senha"];

            novoUsuario.CriarId(novoUsuario);

            usuarioModel.criar(novoUsuario);

            ViewBag.Post = usuarioModel.lertodos();

            return LocalRedirect("~/Home");
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
