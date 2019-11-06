using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Contract
{
    class HourlyContract : IContractService
    {

        public override decimal CalculateAnnualSalary(decimal value)
        {
            decimal salary = hours * value * months;
            return salary;
        }
    }
}
