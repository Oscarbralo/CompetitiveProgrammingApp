using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompetitiveProgrammingApp.Controllers.Pages;
using CompetitiveProgrammingApp.Models;

namespace CompetitiveProgrammingApp.Controllers.Home
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}
