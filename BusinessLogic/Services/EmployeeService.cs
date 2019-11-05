using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        protected int hours = 120;
        protected int months = 12;

        public decimal CalculateAnnualHourlySalary(decimal hourlySalary)
        {
            decimal salary = hours*hourlySalary*months;
            return salary;
        }

        public decimal CalculateAnnualMonthlySalary(decimal monthlySalary)
        {
            decimal salary = monthlySalary * months;
            return salary;
        }
    }
}
