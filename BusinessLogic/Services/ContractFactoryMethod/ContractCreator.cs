using BusinessLogic.Interfaces;
using BusinessLogic.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.ContractFactoryMethod
{
    public class ContractCreator
    {
        public const int HourlySalary = 1;
        public const int MonthlySalary = 2;

        public static IContractService Create(int type)
        {
            switch (type)
            {
                case HourlySalary:
                    return new HourlyContract();
                case MonthlySalary:
                    return new MonthlyContract();
                default:
                    return null;
            }
        }
    }
}
