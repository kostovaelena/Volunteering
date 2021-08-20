using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Volunteering.Data;

namespace Volunteering.Controllers
{
    public class HomeController : Controller
    {
        VolunteeringContext db = new VolunteeringContext();
        public ActionResult Index()
        {
            return View();
        }

     


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}