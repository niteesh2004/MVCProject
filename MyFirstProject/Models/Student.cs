using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstProject.Models
{
   // [Table("Student")]
    public class Student : Person
    {
        //public int ClassnameId {get;set;}
        //Attributes or Annotations
        //[Key]
        //public int PersonId { get; set; }

        //[Required(ErrorMessage = "Last name is required")]
        //[MaxLength(50)]
        //[Display(Name = "Family Name")]
        //public string LastName { get; set; }

        //[Required(ErrorMessage = "First name is required")]
        //[MaxLength(50)]
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }

        [Required(ErrorMessage = "Enrollment date is required")]
        [Display(Name="Enrollment Date")]
        [DisplayFormat(DataFormatString="{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}