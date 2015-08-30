using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompetitiveProgrammingApp.Models;
using System.Net;
using System.Text;
using System.IO;

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
        public ActionResult Register(string email, string username, string password)
        {
            HackerrankModel model = new HackerrankModel();
            model.RegisterSuccess = false;

            var request = (HttpWebRequest)WebRequest.Create("https://www.hackerrank.com//auth/signup");

            var postData = "&username=" + username;
            postData += "&email=" + email;
            postData += "&password=" + password;
            postData += "&first_name=FirstName";
            postData += "&last_name=LastName";
            postData += "&confirm_password=" + password;
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var errorList = GetErrorList(responseString);

            if (errorList.Count() == 0)
            {
                model.RegisterSuccess = true;
            }
            else
            {
                model.ErrorList = errorList;
            }

            return Json(model);
        }

        private static IEnumerable<string> GetErrorList(string responseString)
        {
            var errorIndex = responseString.IndexOf("error");
            var fieldIndex = responseString.IndexOf("fields");

            var errorList = responseString.Substring(errorIndex, fieldIndex - errorIndex).Split('[')[1].Split(']')[0].Split('"');
            return errorList.Where(x => x.Length > 1);
        }

    }
}
