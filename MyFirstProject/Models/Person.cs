using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstProject.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        [Display(Name = "Family Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

       
        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public string ImagePath { get; set; }


        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}