using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeOigaTechEntities>
    {
        GenericRepository<EmployeeOigaTechEntities> _repository = new GenericRepository<EmployeeOigaTechEntities>();

        public List<Employee> GetAll()
        {
            return _repository.GetAll<Employee>();
        }

        public Employee GetById(int id)
        {
            return _repository.GetById<Employee>(id);
        }

        public void Add(Employee item)
        {
            _repository.Add<Employee>(item);
        }

        public void Update(Employee item)
        {
            _repository.Update<Employee>(item);
        }

        public void Delete(Employee item)
        {
            _repository.Delete<Employee>(item);
        }
    }
}
