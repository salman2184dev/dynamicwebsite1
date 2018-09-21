using System.Collections.Generic;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IEmployeeRepository
    {
        int AddOrEdit(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        int Delete(int employeeId);
        Employee GetAnEmployee(int employeeId);

    }
}