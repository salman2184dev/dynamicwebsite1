using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.BLL.Manager;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Web.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeManager _iEmployeeManager= new EmployeeManager();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            var employees = _iEmployeeManager.GetAllEmployees();
            return View(employees);
        }

        public ActionResult AddOrEdit(int id=0)
        {
            Employee employee= new Employee();
            if (id != 0)
            {
                employee = _iEmployeeManager.GetAnEmployee(id);
            }
            return View(employee);
        }

       

        [HttpPost]
        public ActionResult AddOrEdit(Employee employee, HttpPostedFileBase uploadedFile)
        {

            var allowedExtensions = new[] { ".GIF", ".PNG", ".JPG", ".JPEG" };
            if (uploadedFile != null)
            {
                var ext = Path.GetExtension(uploadedFile.FileName);
                if (allowedExtensions.Contains(ext.ToUpper())) //check what type of extension  
                {
                    string myfile = "EmployeeImage" + DateTime.Now.ToString("ddMMyyhhmm") + ext;
                    var path = ConfigurationManager.AppSettings["EmployeeImage"];
                    var finalpath = Path.Combine(Server.MapPath(path), myfile);
                    if (employee.EmployeeId > 0)
                    {
                        var imageName = employee.EmployeeImage;
                        var existingpath = ConfigurationManager.AppSettings["EmployeeImage"];
                        if (System.IO.File.Exists(Server.MapPath(existingpath + imageName)))
                        {
                            System.IO.File.Delete(Server.MapPath(existingpath + imageName));
                        }
                    }
                    employee.EmployeeImage = myfile;
                    uploadedFile.SaveAs(finalpath);
                }
                else
                {
                    Message message = new Message();
                    message.ReturnMessage = "Choose only Image File!";
                    message.MessageType = MessageTypes.Information;
                }
            }
            else
            {
                Message message = new Message();
                message.ReturnMessage = "Select an Image!";
                message.MessageType = MessageTypes.Information;
            }
            var data = _iEmployeeManager.AddOrEdit(employee);
            return Json(new { messageType = data.MessageType, message = data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iEmployeeManager.GetAllEmployees()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            var imageName = _iEmployeeManager.GetAnEmployee(id);

            var path = ConfigurationManager.AppSettings["EmployeeImage"];

                var finalpath = Path.Combine(Server.MapPath(path), imageName.EmployeeImage);

                if (System.IO.File.Exists(finalpath))
                {
                    System.IO.File.Delete(finalpath);
                }
        
            var data = _iEmployeeManager.Delete(id);
            return Json(new {messageType= data.MessageType, message=data.ReturnMessage, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", _iEmployeeManager.GetAllEmployees()) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAnEmployeeById(int employeeId)
        {
            var employee = _iEmployeeManager.GetAnEmployee(employeeId);
            var data = JsonConvert.SerializeObject(employee, Formatting.None,
                new JsonSerializerSettings() {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}