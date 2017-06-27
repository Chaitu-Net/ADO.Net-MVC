using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    
    public class EmpViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }       
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int Did { get; set; }
        public DateTime DOJ { get; set; }

    }
}