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

        novoUsuario.CriarId(novoUsuario);

        usuarioModel.criar(novoUsuario);

        ViewBag.Usuario = usuarioModel.lertodos();

        return Redirect("~/Home");
        }
    }
}