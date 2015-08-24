using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpPost]
        public ActionResult GetIntoHackerrank()
        {
            HomeModel homeModel = new HomeModel();
            homeModel.HackerRankSuccess = true;
            return Json(homeModel);
        }

    }
}
