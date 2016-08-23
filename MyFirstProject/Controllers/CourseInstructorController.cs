using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFirstProject.Models;

namespace MyFirstProject.Controllers
{
    public class CourseInstructorController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: /CourseInstructor/
        public ActionResult Index()
        {
            var courseinstructors = db.CourseInstructors.Include(c => c.course).Include(c => c.instructor);
            return View(courseinstructors.ToList());
        }

        // GET: /CourseInstructor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInstructor courseinstructor = db.CourseInstructors.Find(id);
            if (courseinstructor == null)
            {
                return HttpNotFound();
            }
            return View(courseinstructor);
        }

        // GET: /CourseInstructor/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName");
            return View();
        }

        // POST: /CourseInstructor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CourseId,PersonId")] CourseInstructor courseinstructor)
        {
            if (ModelState.IsValid)
            {
                db.CourseInstructors.Add(courseinstructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseinstructor.CourseId);
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName", courseinstructor.PersonId);
            return View(courseinstructor);
        }

        // GET: /CourseInstructor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInstructor courseinstructor = db.CourseInstructors.Find(id);
            if (courseinstructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseinstructor.CourseId);
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName", courseinstructor.PersonId);
            return View(courseinstructor);
        }

        // POST: /CourseInstructor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CourseId,PersonId")] CourseInstructor courseinstructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseinstructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", courseinstructor.CourseId);
            ViewBag.PersonId = new SelectList(db.Instructors, "PersonId", "LastName", courseinstructor.PersonId);
            return View(courseinstructor);
        }

        // GET: /CourseInstructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInstructor courseinstructor = db.CourseInstructors.Find(id);
            if (courseinstructor == null)
            {
                return HttpNotFound();
            }
            return View(courseinstructor);
        }

        // POST: /CourseInstructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseInstructor courseinstructor = db.CourseInstructors.Find(id);
            db.CourseInstructors.Remove(courseinstructor);
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
