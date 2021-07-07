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
            u.IdUsuario = ViewBag.Idlog;
            if (form.Files.Count > 0)
            {

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/anexos");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                u.ImagemUsuario = $"img/anexos/{file.FileName}";
                HttpContext.Session.SetString("ImagemUsuario", u.ImagemUsuario);
            }
            else{
                u.ImagemUsuario = "anexos/padraoUsuario.png";
            }

            u.Nome = form["Nome"];
            u.Username = form["Username"];
            u.email = form["email"];
            u.IdUsuario = HttpContext.Session.GetString("Id");
            usuarioModel.alterar(u);
            ViewBag.ImagemUsuariolog = u.ImagemUsuario;
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