using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeesAccounting.Models;
using EmployeesAccounting.ViewModels;

namespace EmployeesAccounting.Controllers
{
    [RoutePrefix("Departments")]
    public class DepartmentsController : Controller
    {
        private DepartmentContext db = new DepartmentContext();

        // GET: Departments/ShowDepartments
        [Route("~/ShowDepartments")]
        public ActionResult ShowDepartments()
        {
            return View(db.Departments.ToList());
        }

        // GET: Departments/ShowEmployees
        [Route("~/ShowEmployees")]
        public ActionResult ShowEmployees()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }

        // GET: Departments/DetailsOfDepartment/5
        [Route("DetailsOfDepartment/{id:int=1}")]
        public ActionResult DetailsOfDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/DetailsOfEmployee/5
        [Route("DetailsOfEmployee/{id:int=1}")]
        public ActionResult DetailsOfEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            employee.Department = db.Departments.Find(employee.DepartmentId);
            return View(employee);
        }

        // GET: Departments/CreateDepartment
        [Route("CreateDepartment")]
        public ActionResult CreateDepartment()
        {
            return View();
        }

        // POST: Departments/CreateDepartment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment([Bind(Include = "DepartmentId,Name,DateOfAdding")] Department department)
        {
            department.DateInfoChanging = DateTime.Now.ToShortDateString();
            if (ModelState.IsValidField("Name") && ModelState.IsValidField("DateOfAdding"))
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("ShowDepartments");
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Departments/CreateEmployeeInDepartment
        public ActionResult CreateEmployeeInDepartment([Bind(Include = "EmployeeId,Name,DateOfAdding,DateOfEmployment")] Employee employee)
        {
            employee.DateInfoChanging = DateTime.Now.ToShortDateString();
            employee.DepartmentId = 1;
            return View(employee);
        }

        // GET: Departments/CreateEmployee
        [Route("CreateEmployee")]
        public ActionResult CreateEmployee()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        // POST: Departments/CreateEmployee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee([Bind(Include = "EmployeeId,Name,DateOfAdding,DateInfoChanging,DateOfEmployment,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ShowEmployees");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Departments/EditDepartment/5
        [Route("EditDepartment/{id:int=1}")]
        public ActionResult EditDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/EditDepartment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment([Bind(Include = "DepartmentId,Name,DateOfAdding,DateInfoChanging")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowDepartments");
            }
            return View(department);
        }

        // GET: Departments/EditEmployee/5
        [Route("EditEmployee/{id:int=1}")]
        public ActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Departments/EditEmployee/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee([Bind(Include = "EmployeeId,Name,DateOfAdding,DateInfoChanging,DateOfEmployment,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowEmployees");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Departments/DeleteDepartment/5
        [Route("DeleteDepartment/{id:int=1}")]
        public ActionResult DeleteDepartment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/DeleteDepartment/5
        [HttpPost, ActionName("DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedForDepartment(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("ShowDepartments");
        }


        // GET: Departments/DeleteEmployee/5
        [Route("DeleteEmployee/{id:int=1}")]
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            employee.Department = db.Departments.Find(employee.DepartmentId);
            return View(employee);
        }

        // POST: Departments/DeleteEmployee/5
        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedForEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
