﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess;
using WebApiOigaTech.Models;

namespace WebApiOigaTech.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeOigaTechEntities db = new EmployeeOigaTechEntities();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployee()
        {
            return db.Employee;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
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