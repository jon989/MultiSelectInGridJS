using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiSelectInGrid.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace MultiSelectInGrid.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindRepository repository = new NorthwindRepository();

        public ActionResult Index()
        {
            ViewData["territories"] = repository.Territories;

            return View();
        }

        public ActionResult Read()
        {
            return Json(repository.Employees);
        }

        public ActionResult Update(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEmployee(employee);
            }

            return Json(new[] { employee });
        }

        public ActionResult Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                employee.EmployeeID = repository.CreateEmployee(employee);
            }

            return Json(new[] { employee });
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
