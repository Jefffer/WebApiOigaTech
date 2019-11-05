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

            foreach (Employee emp in employees)
            {
                EmployeeCustom empCustom = new EmployeeCustom {
                    idEmployee = emp.idEmployee,
                    employeeName = emp.employeeName,
                    employeePhone = emp.employeePhone,
                    employeePosition = emp.employeePosition,
                    contractType = db.ContractType.Where(ct => ct.idContractType == emp.fk_ContractType).FirstOrDefault().contractTypeName,
                    hourlySalary = emp.hourlySalary,
                    monthlySalary = emp.monthlySalary,
                    annualHourlySalary = _employeeService.CalculateAnnualHourlySalary(emp.hourlySalary ?? 0),
                    annualMonthlySalary = _employeeService.CalculateAnnualMonthlySalary(emp.monthlySalary ?? 0)
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
        public IHttpActionResult GetEmployee(int id)
        {
           // GetEmployee Employee by ID
            Employee emp = repository.GetById(id);

            if (emp == null)            
                return NotFound();

            EmployeeCustom empCustom = new EmployeeCustom
            {
                idEmployee = emp.idEmployee,
                employeeName = emp.employeeName,
                employeePhone = emp.employeePhone,
                employeePosition = emp.employeePosition,
                contractType = db.ContractType.Where(ct => ct.idContractType == emp.fk_ContractType).FirstOrDefault().contractTypeName,
                hourlySalary = emp.hourlySalary,
                monthlySalary = emp.monthlySalary,
                annualHourlySalary = _employeeService.CalculateAnnualHourlySalary(emp.hourlySalary ?? 0),
                annualMonthlySalary = _employeeService.CalculateAnnualMonthlySalary(emp.monthlySalary ?? 0)
            };

            return Ok(empCustom);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != employee.idEmployee)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

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

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.idEmployee == id) > 0;
        }
    }
}