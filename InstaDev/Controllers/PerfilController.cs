using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
     [Route("Perfil")]
    public class PerfilController : Controller
    {
        Usuario u = new Usuario();

        [Route("{IdUsuario}")]
        public IActionResult Index(string IdUsuario)
        {
            var perfil = u.lertodos().Find(x => x.IdUsuario == IdUsuario);
            ViewBag.Nometeste = perfil.Nome;
            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");
            return View();
        }
    }
}