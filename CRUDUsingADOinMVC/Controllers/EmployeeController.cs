using CRUDUsingADOinMVC.Models;
using CRUDUsingADOinMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingADOinMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
       
        //Get all employee
        public ActionResult GetAllEmployeeDetails()
        {
            EmpRepository empRepo = new EmpRepository();
            ModelState.Clear();
            return View(empRepo.GetAllEmployees());
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmpModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();
                    if (EmpRepo.AddEmployee(emp))
                    {
                        ViewBag.Message = "Employee added successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }
        public ActionResult EditEmployeeDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View(EmpRepo.GetAllEmployees().Find(EmpModel => EmpModel.EmpID == id));
           
        }
        [HttpPost]
        public ActionResult EditEmployeeDetails(int id, EmpModel emp)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                EmpRepo.UpdateEmployee(emp);
                return RedirectToAction("GetAllEmployeeDetails");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.alert = "Employee deleted successfully";

                }
                return RedirectToAction("GetAllEmployeeDetails");
            }
            catch
            {
                return View();
            }
            

        }
        public ActionResult Details(int id)
        {

            return View();
        }
    }
}
