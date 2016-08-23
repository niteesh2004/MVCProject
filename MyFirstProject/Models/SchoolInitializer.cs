using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstProject.Models
{
    public class SchoolInitializer :DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstName = "James", LastName="Dean", EnrollmentDate = DateTime.Parse("2014-01-02")},
                new Student{FirstName = "Lynda", LastName="Thames", EnrollmentDate = DateTime.Parse("2013-11-02")}
            };
            foreach (var temp in students)
            {
                context.Students.Add(temp);
            }
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
            new Instructor { FirstName = "Peter", LastName = "Lee", HireDate = DateTime.Parse("2013-04-10") },
            new Instructor { FirstName = "Ruth", LastName = "Zen", HireDate = DateTime.Parse("2010-12-12") }
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();
                     

                        var departments = new List<Department>
            {
            new Department { Name = "English", Budget = 200000, StartDate = DateTime.Parse("2012-09-01"), PersonId = 3},
            new Department { Name = "Computer Science", Budget = 100000, StartDate = DateTime.Parse("2010-09-01"), PersonId = 4 },

            };
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseId= 100, CourseName = "Java", TotalCredits= 4, DepartmentId = 2},
                new Course{CourseId= 200, CourseName = "C#", TotalCredits= 4, DepartmentId = 2}
            };
            foreach (var temp in courses)
            {
                context.Courses.Add(temp);
            }
            context.SaveChanges();

            //var courses = new List<Course>
            //{
            //    new Course{CourseId= 100, CourseName = "Java", TotalCredits= 4, DepartmentId = 2, Instructors = new List<Instructor>()},
            //    new Course{CourseId= 200, CourseName = "C#", TotalCredits= 4, DepartmentId = 2, Instructors = new List<Instructor>()}
            //};
            //foreach (var temp in courses)
            //{
            //    context.Courses.Add(temp);
            //}
            //context.SaveChanges();

            //courses[0].Instructors.Add(instructors[0]);
            //courses[0].Instructors.Add(instructors[1]);
            //context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{PersonId = 1, CourseId= 100, Grade = 3},
                new Enrollment{PersonId = 1, CourseId= 200, Grade = 4}
            };
            foreach (var temp in enrollments)
            {
                context.Enrollments.Add(temp);
            }
            context.SaveChanges();

            var courseinstructors = new List<CourseInstructor>
            {
                new CourseInstructor{PersonId = 3, CourseId= 100},
                new CourseInstructor{PersonId = 4, CourseId= 100}
            };
            foreach (var temp in courseinstructors)
            {
                context.CourseInstructors.Add(temp);
            }
            context.SaveChanges();

            var customers = new List<Customer> 
            { 
                new Customer { FirstName = "Alex", LastName = "Rod" , 
                    Address = new Address{StreetAddress = "101 Wisconsin Ave"}}, 
                new Customer {FirstName = "Linda", LastName = "Bates",  
                    Address = new Address{StreetAddress = "201 Hill Plaza"}} 

            };
            customers.ForEach(s => context.Customer.Add(s));
            context.SaveChanges();

            var Users = new List<User> 
            { 
                new User { Username = "AlexR",     Email = "alex@some.com", FirstName = "Alex", LastName = "Rod" }, 
                new User { Username = "LindaR",     Email = "linda@some.com", FirstName = "Linda", LastName = "Gates" }, 
            };
            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

        }
    }
}