using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOigaTech.Models
{
    public class EmployeeCustom
    {
        /// <summary>
        /// Employee id (PK in Database)
        /// </summary>
        public int idEmployee { get; set; }

        /// <summary>
        /// Employee Full Name
        /// </summary>
        public string employeeName { get; set; }

        /// <summary>
        /// Employee Phone Number
        /// </summary>
        public string employeePhone { get; set; }

        /// <summary>
        /// Employee position
        /// </summary>
        public string employeePosition { get; set; }

        /// <summary>
        /// Employee Contract Type
        /// </summary>
        public string contractType { get; set; }

        /// <summary>
        /// Employee Hourly Salary
        /// </summary>
        public decimal? hourlySalary { get; set; }

        /// <summary>
        /// Employee Montly Salary
        /// </summary>
        public decimal? monthlySalary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? annualHourlySalary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? annualMonthlySalary { get; set; }
    }
}