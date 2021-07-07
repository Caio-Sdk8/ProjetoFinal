using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Cadastro")]
    public class CadastrarController : Controller
    {
        public Usuario usuarioModel = new Usuario();

        public IActionResult Index()
        {
            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");
            ViewBag.Usuario = usuarioModel.lertodos();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
        Usuario novoUsuario = new Usuario();
        novoUsuario.email = form["Email"];
        novoUsuario.Nome = form["Nome"];
        novoUsuario.Username = form["Username"];
        novoUsuario.senha = form["senha"];
        novoUsuario.ImagemUsuario = "anexos/images.png";

        novoUsuario.CriarId(novoUsuario);

        usuarioModel.criar(novoUsuario);

        ViewBag.Usuario = usuarioModel.lertodos();

        return Redirect("~/Home");
        }
    }
}