using MyFirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstProject.ViewModels
{
    //View Models
    public class Course_Students
    {
        public Course course { get; set; }
        public List<Student> students { get; set; }
    }
}