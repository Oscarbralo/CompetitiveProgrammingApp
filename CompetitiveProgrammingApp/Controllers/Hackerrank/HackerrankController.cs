using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompetitiveProgrammingApp.Models;

namespace CompetitiveProgrammingApp.Controllers.Pages
{
    public class HackerrankController : Controller
    {
        //
        // GET: /Hackerrank/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string email, string username, string password, string firstname, string lastname)
        {
            HackerrankModel model = new HackerrankModel();
            model.IsActive = true;
            return Json(model);
        }

    }
}
