using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstProject.Models
{
    //Composite primary key
    public class TestModel
    {
        [Key, Column(Order = 0)] 
        public int columnOne { get; set; }
        [Key, Column(Order = 1)] 
        public string columnTwo { get; set; }
        
       // [Index]
        public string columnThree { get; set; }

    }
}