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
    public class SmtpHostManager : ISmtpHostManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly ISmtpHostRepository _iSmtpHostRepository;

        public SmtpHostManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iSmtpHostRepository = new SmtpHostRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(SmtpHost smtpHost)
        {
            var message = new Message();
            var ID = smtpHost.SmtpHostId;
            int result = _iSmtpHostRepository.AddOrEdit(smtpHost);
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

        public Message Delete(int smtpHostId)
        {
            var message = new Message();
            try
            {

                int result = _iSmtpHostRepository.Delete(smtpHostId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("smtp Host Deleted Successfully.");
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

        public IEnumerable<SmtpHost> GetAllSmtpHost()
        {
            try
            {

                var smtpHost = _iSmtpHostRepository.GetAllSmtpHost();
                return smtpHost;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SmtpHost GetASmtpHost(int smtpHostId)
        {
            try
            {

                var smtpHost = _iSmtpHostRepository.GetASmtpHost(smtpHostId);
                return smtpHost;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
