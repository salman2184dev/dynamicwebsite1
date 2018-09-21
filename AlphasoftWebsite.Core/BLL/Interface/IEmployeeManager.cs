using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using AlphasoftWebsite.Core.Utility;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IEmployeeManager
    {
        Message AddOrEdit(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        Message Delete(int employeeId);
        Employee GetAnEmployee(int employeeId);
    }
}