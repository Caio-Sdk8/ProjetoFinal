using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Postagem")]
    public class PostController : Controller
    {
        Post postModel = new Post();

        [Route("listar")]
        public IActionResult Index()
        {

            ViewBag.Post = postModel.LerTodas();
            return View();
        }

        
        [Route("CriarPost")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Post novaPostagem = new Post();
            novaPostagem.Descrição = form["Descrição"];

            if (form.Files.Count > 0)
            {

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

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
                novaPostagem.ImagemPost = "padrao.png";
            }

            postModel.Criar(novaPostagem);

            ViewBag.Post = postModel.LerTodas();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(string id){
            postModel.Deletar(id);
            ViewBag.Post = postModel.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}