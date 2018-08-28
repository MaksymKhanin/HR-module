using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_module.Models;
using HR_module.Infrastructure.Repository.DI.Abstract;
using HR_module.Models.Contexts;

namespace HR_module.Controllers
{
    public class CandidatesController : Controller
    {
        ICandidatesRepository<Candidate> db1;
        public CandidatesController(ICandidatesRepository<Candidate>r1)
        {
            db1 = r1;
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}