using Microsoft.AspNetCore.Mvc;
using System;

namespace InstaDev.Controllers
{
    public class ComentárioController : Controller
    {
               public IActionResult Index()
        {
            return View();
        } 
    }
}