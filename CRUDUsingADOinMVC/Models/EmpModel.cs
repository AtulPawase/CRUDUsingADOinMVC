using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUsingADOinMVC.Models
{
    public class EmpModel
    {
        public int EmpID { get; set; }
        public string EName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}