using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BO;
using MVC.Models;
using System.Data;

namespace MVC.Controllers
{
    public class EmpCRUDController : Controller
    {
        // GET: EmpCRUD
        public ActionResult Index()
        {
            DataTable dt = EmployeeDal.DisplayEmployee();
            return View(dt);
        }

        // GET: EmpCRUD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpCRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpCRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpCRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpCRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpCRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpCRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: EmpCRUD/MultipleDataReader
        public ActionResult MultipleReader()
        {
            empBO emp = EmployeeDal.DisplayEmployeesUsingDataReader();
            return View(emp);
        }

        //GET: EmpCRUD/DataAdapter
        public ActionResult DataAdapter()
        {
            DataTable dt = EmployeeDal.DisplayEmployeeUsingDataAdapter();
            return View(dt);
        }

        //GET: EmpCRUD/MultipleDataAdapter
        public ActionResult MultipleAdapter()
        {
            empBO emp = EmployeeDal.DisplayEmployeesUsingDataAdapter();
            return View(emp);
        }

        //Get: EmpCRUD/ScalarValue
        public ActionResult ScalarValue()
        {
            return View();
        }

        //Post: EmpCRUD/ScalarValue
        [HttpPost]
        public ActionResult ScalarValue(Employee emp)
        {
            int id = EmployeeDal.ScalarValue(emp);
            ViewBag.Message = "Scalar Value ID: " + id;
            return View();
        }

        // insert data into first table and get back the Primary Key from first table use that primary key as Foreign key to insert data into second table
        //Get: EmpCRUD/Tb1PKtoTb2FK
        public ActionResult Tb1PKtoTb2FK()
        {
            return View();
        }

        //POST: EmpCRUD/Tb1PKtoTb2FK
        [HttpPost]
        public ActionResult Tb1PKtoTb2FK(Tb1PKtoTb2FKBO insert)
        {
            EmployeeDal.InsertTables(insert);
            return RedirectToAction("Index");
        }

        //Get : EmpCRUD/FindName
        public ActionResult FindName()
        {
            return View();
        }

        //Post : EmpCRUD/FindName
        [HttpPost]
        public ActionResult FindName(Employee emp)
        {
            int id = EmployeeDal.FindName(emp);
            if (id > 0)
            {
                ViewBag.Message = "Name Exists";
            }
            else
            {
                ViewBag.Message = "Name does not Exists";
            }
            return View();
        }

        //Get: EmpCRUD/Multiple Records
        public ActionResult MultipleRecords()
        {
            return View();
        }

        //Post: EmpCRUD/Multiple Records
        [HttpPost]
        public ActionResult MultipleRecords(List<Employee> emp)
        {
            EmployeeDal.MultipleRecords(emp);
            return RedirectToAction("Index");
        }

        //Get: EmpCRUD/CustomTable
        public ActionResult CustomTable()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomTable(int id)
        {

            return View();
        }

        //Get: EmpCRUD/UserExistance
        public ActionResult UserExistance()
        {
            return View();
        }

        //POST: EmpCRUD/UserExistance
        [HttpPost]
        public ActionResult UserExistance(Employee emp)
        {
            Object obj = EmployeeDal.UserExistance(emp);

            if (obj is Employee)
            {
                ViewBag.message = "Name Exists";
                return View(obj);
            }
            else
            {
                ViewBag.Message = "Name does not Exists in Data Base";
            }
            return View();
        }

        // if user age is greater than 58
        //Get:EmpCRUD/DeleteAGE
        public ActionResult DeleteUser()
        {
            return View();
        }

        //Post: EmpCRUD/DeleteAge
        [HttpPost]
        public ActionResult DeleteUser(Employee emp)
        {
            EmployeeDal.DeleteUser(emp);
            return View();
        }

        public ActionResult DeleteAge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAge(Employee emp)
        {
            EmployeeDal.DeleteAge(emp);
            return RedirectToAction("Index");
        }

        //Get: EmpCRUD/UpdateSalary
        public ActionResult UpdateSalary()
        {
            return View();
        }

        //Post: EmpCRUD/Updatesalary
        [HttpPost]
        [ActionName("UpdateSalary")]
        public ActionResult UpdateSal()
        {
            EmployeeDal.UpdateSalary();
            return RedirectToAction("Index");
        }
    }
}