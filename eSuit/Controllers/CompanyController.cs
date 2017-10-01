using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSuitRepository.DataModels;
using eSuitRepository.DataProviders;

namespace eSuit.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        public ActionResult Index()
        {
            Company dpCompany = new Company();
            return View(dpCompany.List());
        }
        public ActionResult Add()
        {
            return View();
        }

    }
}