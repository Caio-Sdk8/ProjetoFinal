using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    public class CadastrarController : Controller
    {
        Usuario usuarioModel = new Usuario();

        public IActionResult Index()
        {
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
        Usuario novoUsuario = new Usuario();
        novoUsuario.email = form["Descrição"];
        novoUsuario.Nome = form["Local"];
        novoUsuario.Username = form["Local"];
        novoUsuario.senha = form["Local"];

        novoUsuario.CriarId(novoUsuario);

        usuarioModel.criar(novoUsuario);

        ViewBag.Post = usuarioModel.lertodos();

        return LocalRedirect("Home");
        }
    }
}