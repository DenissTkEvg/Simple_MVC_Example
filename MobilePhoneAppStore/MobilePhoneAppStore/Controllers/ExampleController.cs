using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobilePhoneAppStore.Controllers
{
    public class ExampleController : Controller
    {
        public string Square2(int a, int b)
        {
            int s = a * b;
            return "<h2>Площадь прямоугольника со сторонами " + a + " и " + b + " равна " + s + "</h2>";
        }
        public string Square()
        {

            int a = Int32.Parse(Request.Params["a"]);
            int b = Int32.Parse(Request.Params["b"]);
            int s = a * b;
            return "<h2>Площадь прямоугольника со сторонами " + a + " и " + b + " равна " + s + "</h2>";

        }
        [HttpGet]
        public ActionResult Get_Book()
        {
            return View();
        }
        [HttpPost]
        public string Post_Book()
        {
            string Name = Request.Form["Name"];
            string Autor = Request.Form["Autor"];
            return "<h2>" + Name + " " + Autor + "</h2>";
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}