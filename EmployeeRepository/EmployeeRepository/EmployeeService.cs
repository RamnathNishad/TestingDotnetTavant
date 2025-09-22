using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRepository
{
    
    public class EmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repo)
        {
            this.repository = repo;            
        }

        public Employee GetEmployee(int id)
        {
            var emp=repository.GetEmployee(id);
            if (emp == null)
                throw new Exception("Employee not found");

            return emp;
        }
        public List<Employee> GetEmployees() 
        {
            var emps = repository.GetAllEmployees();
            return emps;
        }

        public int RegisterEmployee(Employee employee)
        {
            if(string.IsNullOrEmpty(employee.Name))
            {
                throw new ArgumentException("Employee name is required");
            }

            int id=repository.AddEmployee(employee);
            return id;
        }

        public Employee GetHighestPaidEmployee()
        {
            var emps = repository.GetAllEmployees();
            if (emps.Count == 0) throw new Exception("No employees found");

            return emps.OrderByDescending(e => e.Salary).First();
        }

    }
}
