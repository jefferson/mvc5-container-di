using Containers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Containers.Controllers
{
    public class HomeController : Controller
    {
        private ITestTag _testTag;

        public HomeController(ITestTag testTag)
        {
            _testTag = testTag;
        }

        public ActionResult Index()
        {           
            ViewBag.tagIsOnline = _testTag.TagIsOnline("CEMIG Meetups");
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