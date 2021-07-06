using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
     [Route("Perfil")]
    public class PerfilController : Controller
    {
        Usuario u = new Usuario();

        [Route("{ID}")]
        public IActionResult Index(string ID)
        {
            var perfil = u.lertodos().Find(x => x.IdUsuario == ID);
            ViewBag.Nometeste = perfil.Nome;
            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");
            return View();
        }
    }
}