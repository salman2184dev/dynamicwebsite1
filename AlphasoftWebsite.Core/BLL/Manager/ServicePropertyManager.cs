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
    public class ServicePropertyManager : IServicePropertyManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IServicePropertyRepository _iServicePropertyRepository;

        public ServicePropertyManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iServicePropertyRepository = new ServicePropertyRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(ServiceProperty serviceProperty)
        {
            var message = new Message();
            var ID = serviceProperty.ServiceId;
            int result = _iServicePropertyRepository.AddOrEdit(serviceProperty);
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

        public Message Delete(int servicePropertyId)
        {
            var message = new Message();
            try
            {

                int result = _iServicePropertyRepository.Delete(servicePropertyId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Service Property Deleted Successfully.");
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

        public IEnumerable<ServiceProperty> GetAllServiceProperty()
        {
            try
            {

                var serviceProperty = _iServicePropertyRepository.GetAllServiceProperty();
                return serviceProperty;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceProperty GetAServiceProperty(int servicePropertyId)
        {
            try
            {

                var serviceProperty = _iServicePropertyRepository.GetAServiceProperty(servicePropertyId);
                return serviceProperty;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
