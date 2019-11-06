using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public abstract class IContractService
    {
        internal int hours = 120;
        internal int months = 12;
        public abstract decimal CalculateAnnualSalary(decimal value);
    }
}
