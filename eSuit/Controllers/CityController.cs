using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSuitRepository.DataModels;
using eSuitRepository.DataProviders;

namespace eSuit.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/
        public ActionResult Index()
        {
            City dpCity = new City();
            return View(dpCity.List(null, null));
        }

        public ActionResult Add(string message)
        {
            Company dpCompany = new Company();
            ViewBag.ddlCompany = dpCompany.Dropdown();
            Country dpCountry = new Country();
            ViewBag.ddlCountry = dpCountry.Dropdown(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SETUP_City city)
        {
            City dpCity = new City();
            int id = dpCity.Add(city);
            if (id > 0)
            {
                return RedirectToAction("Index", "City");
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Add", "City");
            }
        }

        public ActionResult ViewDetail(int id)
        {
            City dpCity = new City();
            return View(dpCity.Get(id));
        }

        public ActionResult Edit(int id, string message)
        {
            City dpCity = new City();
            Company dpCompany = new Company();
            ViewBag.ddlCompany = dpCompany.Dropdown();
            Country dpCountry = new Country();
            ViewBag.ddlCountry = dpCountry.Dropdown(null);
            return View(dpCity.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SETUP_City city)
        {
            City dpCity = new City();
            bool updated = dpCity.Update(city);
            if (updated)
            {
                return RedirectToAction("ViewDetail", "City", new { id = city.City_Id });
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Edit", "City", new { id = city.City_Id });
            }
        }

        public ActionResult Delete(int id)
        {
            City dpCity = new City();
            dpCity.Delete(id);
            return RedirectToAction("Index", "City");
        }

    }
}