using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyFirstProject.Models;
using System.IO;
using log4net;

namespace MyFirstProject.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        ILog logger = LogManager.GetLogger(typeof(StudentController));

        public ActionResult Search(string SearchBox)
        {
            //    throw new HttpException(404, "Bad Request");
            //    throw new Exception("Id not found");
            //Select * from db.Students s where s.LastName =  SearchBox
            var students = (from s in db.Students
                           where s.LastName.Contains(SearchBox)
                           || s.FirstName.Contains(SearchBox)
                           select s).ToList();
            return View("Index",students);
        }
        // GET: /Student/
        public ActionResult Index()
        {
            //var students = db.Students.ToList();
            //Linq to SQL
            //var students = (from s in db.Students select s).ToList();
            //Linq to Entities
            logger.Info("enter student index");
            return View(db.Students.ToList());
            
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                logger.Error("No id");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                logger.Error("No id");
                return HttpNotFound();
            }
            logger.Debug("return student");
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult GetImage(int id)
        {
            byte[] imageData = db.Students.Find(id).Picture;
            return File(imageData, "image/jpeg"); // depends on the type of image
        }


        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,LastName,FirstName,EnrollmentDate")] Student student, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
	                {
	                    string pic = System.IO.Path.GetFileName(ImageFile.FileName);
	                    string path = System.IO.Path.Combine(
	                                           Server.MapPath("~/images/profile"), pic);
	                    
	                    // file is uploaded
	                    ImageFile.SaveAs(path);

	                    student.ImagePath = pic;
	
	                    // save the image path path to the database or you can send image 
	                    // directly to database
	                    // in-case if you want to store byte[] ie. for DB
	                    using (MemoryStream ms = new MemoryStream())
	                    {
	                        ImageFile.InputStream.CopyTo(ms);
	                        //byte[] Picture = ms.GetBuffer();
                            student.Picture = ms.GetBuffer();
	                    }
	
	                }


                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/5&abc=hhhh
        //localhost:52429/Student/Edit?xyz=1&abc=hhhh
        public ActionResult Edit(int? id, string abc)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PersonId,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
