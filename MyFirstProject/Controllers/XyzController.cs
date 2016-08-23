using MyFirstProject.Models;
using MyFirstProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstProject.Controllers
{
    public class XyzController : Controller
    {
        private SchoolContext db = new SchoolContext();
        //
        // GET: /Xyz/
        public ActionResult Abc()
        {
            var students = db.Students.ToList();
            return View(students);
            //Course math = new Course();
            //math.CourseName = "Math 101";
            //math.TotalCredits = 4;

            //Student alex = new Student();
            //alex.FirstName = "Alex";
            //alex.LastName = "Rod";

            //Student lynda = new Student();
            //lynda.FirstName = "Lynda";
            //lynda.LastName = "Berry";

            //Student john = new Student();
            //john.FirstName = "John";
            //john.LastName = "Doe";

            //List<Student> students = new List<Student>();
            //students.Add(alex);
            //students.Add(lynda);
            //students.Add(john);

            //Course_Students obj = new Course_Students();
            //obj.course = math;
            //obj.students = students;
            
            //return View(obj);
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}