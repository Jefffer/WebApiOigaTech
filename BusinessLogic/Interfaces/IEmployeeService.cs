using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        decimal CalculateAnnualHourlySalary(decimal hourlySalary);
        decimal CalculateAnnualMonthlySalary(decimal monthlySalary);
    }
}
