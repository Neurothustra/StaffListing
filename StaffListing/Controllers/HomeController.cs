using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Peirce.FacultySearch.Models;

namespace Web.Peirce.FacultySearch.Controllers
{
    //For open-source purposes, there is no login validation needed
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private FacultyContext db = new FacultyContext();

        public ActionResult Index(int id = 1)
        {
            var deptName = db.Departments.Find(id);
            ViewBag.departmentName = deptName.DepartmentName;

            var facultymembers = db.FacultyMembers.Include(f => f.Department)
                .Where(d => d.DepartmentId == id)
                .OrderBy(n => n.LastName)
                .ToList();
            return View(facultymembers);
        }

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyId,Prefix,FirstName,MiddleName,LastName,Suffix,JobTitle,Email,Telephone,DepartmentId")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.FacultyMembers.Add(faculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", faculty.DepartmentId);
            return View(faculty);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.FacultyMembers.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", faculty.DepartmentId);
            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyId,Prefix,FirstName,MiddleName,LastName,Suffix,JobTitle,Email,Telephone,DepartmentId")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", faculty.DepartmentId);
            return View(faculty);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty faculty = db.FacultyMembers.Find(id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = db.FacultyMembers.Find(id);
            db.FacultyMembers.Remove(faculty);
            db.SaveChanges();
            return RedirectToAction("Index");
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
