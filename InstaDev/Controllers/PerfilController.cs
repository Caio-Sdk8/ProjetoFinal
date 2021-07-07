using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
     [Route("Perfil")]
    public class PerfilController : Controller
    {
        Post postModel = new Post();
        Usuario u = new Usuario();

        comentario comentarioModel = new comentario();

        [Route("{ID}")]
        public IActionResult Index(string ID)
        {
            var perfil = u.lertodos().Find(x => x.IdUsuario == ID);
            ViewBag.Nome = perfil.Nome;
            ViewBag.Username = perfil.Username;
            ViewBag.ImagemUsuario = perfil.ImagemUsuario;
            ViewBag.idteste = perfil.IdUsuario;

            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");

            ViewBag.Post = postModel.LerTodas();
            ViewBag.Comentarios = comentarioModel.listas();
            return View();
        }

        [Route("Logout")]
        public IActionResult logout(){
            HttpContext.Session.Remove("Username");
            return Redirect("~/Home");
        }
    }
}