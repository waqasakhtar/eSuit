﻿using System;
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

        public ActionResult Add(string message)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SETUP_Company company)
        {
            Company dpCompany = new Company();
            int id = dpCompany.Add(company);
            if (id > 0)
            {
                return RedirectToAction("Index", "Company");
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Add", "Company");
            }
        }

        public ActionResult ViewDetail(int id)
        {
            Company dpCompany = new Company();
            return View(dpCompany.Get(id));
        }

        public ActionResult Edit(int id, string message)
        {
            Company dpCompany = new Company();
            return View(dpCompany.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SETUP_Company company)
        {
            Company dpCompany = new Company();
            bool updated = dpCompany.Update(company);
            if (updated)
            {
                return RedirectToAction("ViewDetail", "Company", new { id = company.Comp_Id });
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Edit", "Company", new { id = company.Comp_Id });
            }
        }

        public ActionResult Delete(int id)
        {
            Company dpCompany = new Company();
            dpCompany.Delete(id);
            return RedirectToAction("Index", "Company");
        }

    }
}