using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSuitRepository.DataModels;
using eSuitRepository.DataProviders;

namespace eSuit.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/
        public ActionResult Index()
        {
            Country dpCountry = new Country();
            return View(dpCountry.List(null));
        }

        public ActionResult Add(string message)
        {
            Company dpCompany = new Company();
            ViewBag.ddlCompany = dpCompany.Dropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SETUP_Country country)
        {
            Country dpCountry = new Country();
            int id = dpCountry.Add(country);
            if (id > 0)
            {
                return RedirectToAction("Index", "Country");
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Add", "Country");
            }
        }

        public ActionResult ViewDetail(int id)
        {
            Country dpCountry = new Country();
            return View(dpCountry.Get(id));
        }

        public ActionResult Edit(int id, string message)
        {
            Country dpCountry = new Country();
            Company dpCompany = new Company();
            ViewBag.ddlCompany = dpCompany.Dropdown();
            return View(dpCountry.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SETUP_Country country)
        {
            Country dpCountry = new Country();
            bool updated = dpCountry.Update(country);
            if (updated)
            {
                return RedirectToAction("ViewDetail", "Country", new { id = country.Cont_Id });
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Edit", "Country", new { id = country.Cont_Id });
            }
        }

        public ActionResult Delete(int id)
        {
            Country dpCountry = new Country();
            dpCountry.Delete(id);
            return RedirectToAction("Index", "Country");
        }

    }
}