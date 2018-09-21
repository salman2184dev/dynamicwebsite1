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
    public class SoftwareManager : ISoftwareManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly ISoftwareRepository _iSoftwareRepository;

        public SoftwareManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iSoftwareRepository = new SoftwareRepository(_AlphasoftWebsiteContext);
        }
        public Message AddOrEdit(Software software)
        {
            var message = new Message();
            var ID = software.SoftwareId;
            int result = _iSoftwareRepository.AddOrEdit(software);
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

        public Message Delete(int softwareId)
        {
            var message = new Message();
            try
            {

                int result = _iSoftwareRepository.Delete(softwareId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Software Deleted Successfully.");
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

        public IEnumerable<Software> GetAllSoftware()
        {
            try
            {

                var product = _iSoftwareRepository.GetAllSoftware();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Software GetASoftware(int softwareId)
        {
            try
            {

                var product = _iSoftwareRepository.GetASoftware(softwareId);
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
