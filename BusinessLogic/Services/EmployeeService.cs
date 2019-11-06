using BusinessLogic.Interfaces;
using BusinessLogic.Services.ContractFactoryMethod;
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
            IContractService contract = ContractCreator.Create(ContractCreator.HourlySalary);
            decimal salary = contract.CalculateAnnualSalary(hourlySalary);
            return salary;
        }

        public decimal CalculateAnnualMonthlySalary(decimal monthlySalary)
        {
            IContractService contract = ContractCreator.Create(ContractCreator.MonthlySalary);
            decimal salary = contract.CalculateAnnualSalary(monthlySalary);
            return salary;
        }
    }
}
