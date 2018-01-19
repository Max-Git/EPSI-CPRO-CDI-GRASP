using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppliWeb.Models;
using AppliWeb.ModelBuilder;

namespace AppliWeb.Controllers
{
    public class HomeController : Controller
    {
        MyModelBuilder builder = new MyModelBuilder();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page. TOTO";

            return View(builder.createAboutVM());
        }
        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
