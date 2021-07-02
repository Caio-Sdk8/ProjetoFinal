using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    public class PerfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}