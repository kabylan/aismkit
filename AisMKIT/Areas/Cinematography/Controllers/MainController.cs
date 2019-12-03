using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    public class MainController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InfoISRC()
        {
            return View();
        }
        public IActionResult InfoUchastieKonkurs()
        {
            return View();
        }
    }
}