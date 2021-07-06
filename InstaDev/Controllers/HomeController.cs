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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");
            return View();
        }
        [TempData]
        public string mensagem { get; set; }
        
        
        Usuario usermodel = new Usuario();

        public IActionResult Index(){
            return View();
        }
        
        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            List<string> userCSV = usermodel.lertodaslinhasCSV("Database/Usuarios.csv");
            var logado = userCSV.Find(x => x.Split(";")[3] == form["Email"] && x.Split(";")[4] == form["Senha"]);
            var tentativa = form["Email"];
            if (logado != null)
            {
                HttpContext.Session.SetString("Id", logado.Split(";")[0]);
                HttpContext.Session.SetString("Nome", logado.Split(";")[1]);
                HttpContext.Session.SetString("Username", logado.Split(";")[2]);
                HttpContext.Session.SetString("ImagemUsuario", logado.Split(";")[5]);
                ViewBag.UsuarioLog = logado;
                return Redirect("~/Feed");
            }
            return LocalRedirect("~/");
        }

        [Route("Logout")]
        public IActionResult logout(){
            HttpContext.Session.Remove("Username");
            return LocalRedirect("~/");
        }
    }
}
