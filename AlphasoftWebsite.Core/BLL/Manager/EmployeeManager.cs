using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.DAL.Repository;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IEmployeeRepository _iEmployeeRepository;

        public EmployeeManager()
        {
            _AlphasoftWebsiteContext= new AlphasoftWebsiteContext();
            _iEmployeeRepository= new EmployeeRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(Employee employee)
        {
            var message = new Message();
            var ID = employee.EmployeeId;
            int result = _iEmployeeRepository.AddOrEdit(employee);
            try
            {
                if (result > 0)
                {
                    if (Convert.ToInt32(ID) > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Updated Successfully!");
                    }
                    else
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Successful!");
                    }

                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Could not be submitted!");
                }
            }
            catch (Exception e)
            {
                message = Message.SetMessages.SetWarningMessage(e.Message.ToString());
            }

            return message;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                
                var employees = _iEmployeeRepository.GetAllEmployees();
                return employees;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Message Delete(int employeeId)
        {
            var message = new Message();
            try
            {
                
                int result = _iEmployeeRepository.Delete(employeeId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Employee Deleted Successfully.");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Failed to Delete Data.");
                }

            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }
            
            return message;
        }

        public Employee GetAnEmployee(int employeeId)
        {
            try
            {

                var employee = _iEmployeeRepository.GetAnEmployee(employeeId);
                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
