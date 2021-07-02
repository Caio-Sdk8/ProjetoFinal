using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    public class UsuarioController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("listar")]
        public IActionResult Index()
        {

            ViewBag.Usuario = usuarioModel.lertodos();
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

            return LocalRedirect("");
        }

        [Route("{id}")]
        public IActionResult Editar(IFormCollection form, string id){
            Usuario u = new Usuario();
            u.IdUsuario = id;
            if (form.Files.Count > 0)
            {

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Postagens");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            else{
                u.ImagemUsuario = "padraoUsuario.png";
            }
            u.Nome = form["Nome"];
            u.Username = form["Username"];
            u.email = form["email"];

            usuarioModel.alterar(u);
            return LocalRedirect("");
        }

        [Route("{id}")]
        public IActionResult Excluir(string id)
        {
            usuarioModel.deletar(id);
            ViewBag.Usuario = usuarioModel.lertodos();
            return LocalRedirect("");
        }
    }
}