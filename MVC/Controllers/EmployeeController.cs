using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmpViewModel emp = new EmpViewModel();
            return View(emp);
        }

        public ActionResult GetEmployee()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SaveEmployee(EmpViewModel model)
        {

            return View();
        }
    }
}