using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstProject.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Course Number")]
        public int CourseId { get; set; }

        [Required(ErrorMessage="Title is required")]
        [MaxLength(50)]
        [Display(Name = "Title")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Number of credits is required.")]
        [Range(0, 5, ErrorMessage = "Number of credits must be between 0 and 5.")]
        [Display(Name = "Credits")]
        public int TotalCredits { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

    }
}