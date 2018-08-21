using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_module.Models;

namespace HR_module.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Candidate> db1;
        public HomeController(IRepository<Candidate>r1)
        {
            db1 = r1;
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}