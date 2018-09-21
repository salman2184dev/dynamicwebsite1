using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        // GET: Designation        
        public static AlphasoftWebsiteContext _dbContext;

        public EmployeeRepository(AlphasoftWebsiteContext dbContext)
        {            
            _dbContext = dbContext;           
        }
        


        public IEnumerable<Employee> GetAllEmployees()
        {
            var employeeList = _dbContext.Employees.Include(a=>a.Designation).ToList();
            return employeeList;
        }

        public int AddOrEdit(Employee employee)
        {           
            if (employee.EmployeeId == 0)
            {
                employee.CreatedDate = DateTime.Now;
                employee.UpdatedDate = DateTime.Now;
                employee.CreatedBy = 1;
                employee.UpdatedBy = 1;
                _dbContext.Employees.Add(employee);                
            }
            else
            {
                employee.UpdatedBy = 1;
                employee.UpdatedDate = DateTime.Now;
                _dbContext.Entry(employee).State = EntityState.Modified;                
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int employeeId)
        {
            var employee = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
            }

            return _dbContext.SaveChanges();
            ;
        }

        public Employee GetAnEmployee(int employeeId)
        {
            
            var employee = _dbContext.Employees.Include(a=>a.Designation).FirstOrDefault(x => x.EmployeeId == employeeId);
            return employee;
        }
    }
}