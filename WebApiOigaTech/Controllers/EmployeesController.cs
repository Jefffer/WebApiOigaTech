using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using WebApiOigaTech.Models;

namespace WebApiOigaTech.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeOigaTechEntities db = new EmployeeOigaTechEntities();
        private EmployeeRepository repository = new EmployeeRepository();
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }        

        /// <summary>
        /// Get a List of Custom Employees
        /// </summary>
        /// <returns></returns>
        // GET: api/Employees
        public List<EmployeeCustom> GetEmployee()
        {
            List<Employee> employees = repository.GetAll();

            // New Employee custom list
            List<EmployeeCustom> empCustomList = new List<EmployeeCustom>();
            decimal currentSalary;

            foreach (Employee emp in employees)
            {
                if (emp.fk_ContractType == 1) // Hourly Salary                
                    currentSalary = _employeeService.CalculateAnnualHourlySalary(emp.hourlySalary ?? 0);                
                else // Monthly Salary
                    currentSalary = _employeeService.CalculateAnnualMonthlySalary(emp.monthlySalary ?? 0);

                EmployeeCustom empCustom = new EmployeeCustom {
                    idEmployee = emp.idEmployee,
                    employeeName = emp.employeeName,
                    employeePhone = emp.employeePhone,
                    employeePosition = emp.employeePosition,
                    contractType = db.ContractType.Where(ct => ct.idContractType == emp.fk_ContractType).FirstOrDefault().contractTypeName,
                    hourlySalary = emp.hourlySalary,
                    monthlySalary = emp.monthlySalary,
                    annualHourlySalary = currentSalary,
                    //annualMonthlySalary = _employeeService.CalculateAnnualMonthlySalary(emp.monthlySalary ?? 0)
                };

                empCustomList.Add(empCustom);
            }
            return empCustomList;
        }

        /// <summary>
        /// Get a specific Custom Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeCustom))]
        public List<EmployeeCustom> GetEmployee(int id)
        {
           // GetEmployee Employee by ID
            Employee emp = repository.GetById(id);

            if (emp == null)            
                return null;

            decimal currentSalary;
            if (emp.fk_ContractType == 1) // Hourly Salary                
                currentSalary = _employeeService.CalculateAnnualHourlySalary(emp.hourlySalary ?? 0);
            else // Monthly Salary
                currentSalary = _employeeService.CalculateAnnualMonthlySalary(emp.monthlySalary ?? 0);

            EmployeeCustom empCustom = new EmployeeCustom
            {
                idEmployee = emp.idEmployee,
                employeeName = emp.employeeName,
                employeePhone = emp.employeePhone,
                employeePosition = emp.employeePosition,
                contractType = db.ContractType.Where(ct => ct.idContractType == emp.fk_ContractType).FirstOrDefault().contractTypeName,
                hourlySalary = emp.hourlySalary,
                monthlySalary = emp.monthlySalary,
                annualHourlySalary = currentSalary,
                //annualMonthlySalary = _employeeService.CalculateAnnualMonthlySalary(emp.monthlySalary ?? 0)
            };
            List<EmployeeCustom> empList = new List<EmployeeCustom>();
            empList.Add(empCustom);
            return empList;
        }                

        /// <summary>
        /// Create a new Employee and save it in Database 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        // POST: api/Employees
        [ResponseType(typeof(EmployeeCustom))]
        public IHttpActionResult PostEmployee(EmployeeCustom employee)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            
            // Mapping Employee
            Employee _employee = new Employee {
                employeeName = employee.employeeName,
                employeePhone = employee.employeePhone,
                employeePosition = employee.employeePosition,
                hourlySalary = employee.hourlySalary,
                monthlySalary = employee.monthlySalary,
                fk_ContractType = db.ContractType.Where(ct => ct.contractTypeName == employee.contractType).FirstOrDefault().idContractType
            };

            db.Employee.Add(_employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.idEmployee }, employee);
        }        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}