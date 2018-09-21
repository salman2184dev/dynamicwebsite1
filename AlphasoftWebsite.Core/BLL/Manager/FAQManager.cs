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
    public class FAQManager : IFAQManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IFAQRepository _iFAQRepository;

        public FAQManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iFAQRepository = new FAQRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(FAQ FAQ)
        {
            var message = new Message();
            var ID = FAQ.FAQId;
            int result = _iFAQRepository.AddOrEdit(FAQ);
            try
            {
                if (result > 0)
                {
                    if (Convert.ToInt32(ID) > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Updated Successful!");
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

        public IEnumerable<FAQ> GetAllFAQs()
        {
            try
            {

                var FAQs = _iFAQRepository.GetAllFAQs();
                return FAQs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Message Delete(int FAQId)
        {
            var message = new Message();
            try
            {

                int result = _iFAQRepository.Delete(FAQId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("FAQ Deleted Successfully.");
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

        public FAQ GetAnFAQ(int FAQId)
        {
            try
            {

                var FAQ = _iFAQRepository.GetAnFAQ(FAQId);
                return FAQ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
