using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eSuitRepository.DataModels;
using eSuitRepository.DataProviders;

namespace eSuit.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        public ActionResult Index()
        {
            Department dpDepartment = new Department();
            return View(dpDepartment.List(null));
        }

        public ActionResult Add(string message)
        {
            Company dpCompany = new Company();
            ViewBag.ddlCompany = dpCompany.Dropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SETUP_Department department)
        {
            Department dpDepartment = new Department();
            int id = dpDepartment.Add(department);
            if (id > 0)
            {
                return RedirectToAction("Index", "Department");
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Add", "Department");
            }
        }

        public ActionResult ViewDetail(int id)
        {
            Department dpDepartment = new Department();
            return View(dpDepartment.Get(id));
        }

        public ActionResult Edit(int id, string message)
        {
            Department dpDepartment = new Department();
            Company dpCompany = new Company();
            ViewBag.ddlCompany = dpCompany.Dropdown();
            return View(dpDepartment.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SETUP_Department department)
        {
            Department dpDepartment = new Department();
            bool updated = dpDepartment.Update(department);
            if (updated)
            {
                return RedirectToAction("ViewDetail", "Department", new { id = department.Dep_Id });
            }
            else
            {
                TempData["error"] = "Opps! Somthing went wrong!";
                return RedirectToAction("Edit", "Department", new { id = department.Dep_Id });
            }
        }

        public ActionResult Delete(int id)
        {
            Department dpDepartment = new Department();
            dpDepartment.Delete(id);
            return RedirectToAction("Index", "Department");
        }

    }
}