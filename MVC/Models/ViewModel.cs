using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ViewModel
    {
        public List<EmpViewModel> empVM { get; set; }

        public List<DeptViewModel> deptVM { get; set; }
    }
}