using System.IO;
using InstaDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{

    [Route("Edit")]
    public class EditarController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nomelog = HttpContext.Session.GetString("Nome");
            ViewBag.Emaillog = HttpContext.Session.GetString("email");
            ViewBag.Usernamelog = HttpContext.Session.GetString("Username");
            ViewBag.Idlog = HttpContext.Session.GetString("Id");
            ViewBag.senhalog = HttpContext.Session.GetString("senha");
            ViewBag.ImagemUsuariolog = HttpContext.Session.GetString("ImagemUsuario");
            return View();
        }
        
        Usuario usuarioModel = new Usuario();

        [Route("Editar")]
        public IActionResult Editar(IFormCollection form){
            Usuario u = new Usuario();
            u.IdUsuario = HttpContext.Session.GetString("Id");
            u.senha = HttpContext.Session.GetString("senha");
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
            u.Username = form["Username"];
            u.email = form["email"];
            u.Nome = form["Nome"];
            if (u.Nome == "")
            {
                u.Nome = ViewBag.Nomelog;
            }
            if (u.Username == "")
            {
                u.Username = ViewBag.Usernamelog;
            }
            if (u.email == "")
            {
                u.email = ViewBag.Emaillog;
            }
            if (u.ImagemUsuario == "" || u.ImagemUsuario == "anexos/images.png")
            {
                u.ImagemUsuario = ViewBag.ImagemUsuariolog;
            }

            usuarioModel.alterar(u); 

            return Redirect("~/Edit");
        }

        [Route("{id}")]
        public IActionResult Excluir(string id)
        {
            usuarioModel.deletar(id);
            ViewBag.Usuario = usuarioModel.lertodos();
            return LocalRedirect("~/Home");
        }
    }
}