using System;
using System.Collections.Generic;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
     [Route("Login")]
    public class LoginController : Controller
    {
         [TempData]
        public string mensagem { get; set; }
        
        
        Usuario usermodel = new Usuario();

        public IActionResult Index(){
            return View();
        }
        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            List<string> userCSV = usermodel.lertodaslinhasCSV("Database/jogador.csv");
            var logado = userCSV.Find(x => x.Split(";")[3] == form["Email"] && x.Split(";")[4] == form["Senha"]);
            var tentativa = form["Email"];
            
            if (logado != null)
            {
                HttpContext.Session.SetString("Username", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
            return LocalRedirect("~/Login");
            
        }

        [Route("Logout")]
        public IActionResult logout(){
            HttpContext.Session.Remove("Username");
            return LocalRedirect("~/");
        }
    }
}