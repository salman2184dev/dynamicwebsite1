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
    public class ServiceManager : IServiceManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IServiceRepository _iServiceRepository;

        public ServiceManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iServiceRepository = new ServiceRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(Service service)
        {
            var message = new Message();
            var ID = service.ServiceId;
            int result = _iServiceRepository.AddOrEdit(service);
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


        public Message Delete(int serviceId)
        {
            var message = new Message();
            try
            {

                int result = _iServiceRepository.Delete(serviceId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Service Deleted Successfully.");
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

        public IEnumerable<Service> GetAllService()
        {
            try
            {

                var service = _iServiceRepository.GetAllService();
                return service;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Service GetAService(int serviceId)
        {
            try
            {

                var service = _iServiceRepository.GetAService(serviceId);
                return service;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
