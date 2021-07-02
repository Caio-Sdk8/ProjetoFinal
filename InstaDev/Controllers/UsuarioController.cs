using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    public class UsuarioController : Controller
    {
        // Usuario usuarioModel = new Usuario();

        // [Route("listar")]
        // public IActionResult Index()
        // {

        //     ViewBag.Usuario = usuarioModel.lertodos();
        //     return View();
        // }
        
        // [Route("Cadastrar")]
        // public IActionResult Cadastrar(IFormCollection form)
        // {
        //     Usuario novoUsuario = new Usuario();
        //     novoUsuario.email = form["Descrição"];
        //     novoUsuario.Nome = form["Local"];
        //     novoUsuario.Username = form["Local"];
        //     novoUsuario.senha = form["Local"];

        //     novoUsuario.CriarId(novoUsuario);

        //     usuarioModel.criar(novoUsuario);

        //     ViewBag.Post = usuarioModel.lertodos();

        //     return LocalRedirect("");
        // }

        // [Route("{id}")]
        // public IActionResult Excluir(string id){
        //     usuarioModel.deletar(id);
        //     ViewBag.Usuario = usuarioModel.lertodos();
        //     return LocalRedirect("");
        // }
    }
}