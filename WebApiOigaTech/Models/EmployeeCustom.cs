using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOigaTech.Models
{
    public class EmployeeCustom
    {    
        public int idEmployee { get; set; }
        public string employeeName { get; set; }
        public string employeePhone { get; set; }
        public string employeePosition { get; set; }
        public string contractType { get; set; }
        public decimal? hourlySalary { get; set; }
        public decimal? monthlySalary { get; set; }
        public decimal? annualHourlySalary { get; set; }
        public decimal? annualMonthlySalary { get; set; }
    }
}