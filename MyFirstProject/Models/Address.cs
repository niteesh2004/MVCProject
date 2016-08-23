using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstProject.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }

        public virtual Customer Customer { get; set; }

    }
}