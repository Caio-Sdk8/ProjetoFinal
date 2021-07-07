using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        public Usuario usuarioModel = new Usuario();
        Post postModel = new Post();
        comentario comentarioModel = new comentario();
        public IActionResult Index()
        {
            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");
            ViewBag.Post = postModel.LerTodas();
            ViewBag.Usuario = usuarioModel.lertodos();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Post novaPostagem = new Post();

            novaPostagem.IdUsuario = ViewBag.Id;
            novaPostagem.Descrição = form["Descrição"];
            novaPostagem.Local = form["Local"];
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
                novaPostagem.ImagemPost = file.FileName;
            }
            else
            {
                novaPostagem.ImagemPost = "anexos/images.png";
            }

            novaPostagem.CriarId(novaPostagem);

            postModel.Criar(novaPostagem);

            ViewBag.Post = postModel.LerTodas();

            return LocalRedirect("~/Feed");
        }

        [Route("{id}")]
        public IActionResult Excluir(string id)
        {
            postModel.Deletar(id);
            ViewBag.Post = postModel.LerTodas();
            return LocalRedirect("~/Feed");
        }
        
        [Route("comentar")]
        public IActionResult comentar(IFormCollection form)
        {
            comentario c = new comentario();
            c.comment = form["comentário da pessoa"];
            c.CriarId(c);
            //salvar o que foi escrito
            comentarioModel.cadastrar(c);
            return LocalRedirect("~/Feed");
        }
    }
}