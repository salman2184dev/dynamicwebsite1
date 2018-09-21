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
    public class FAQHeaderManager : IFAQHeaderManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IFAQHeaderRepository _iFAQHeaderRepository;

        public FAQHeaderManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iFAQHeaderRepository = new FAQHeaderRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(FAQHeader faqHeader)
        {
            var message = new Message();
            var ID = faqHeader.FAQHeaderId;
            int result = _iFAQHeaderRepository.AddOrEdit(faqHeader);
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

        public Message Delete(int FAQHeaderId)
        {
            var message = new Message();
            try
            {

                int result = _iFAQHeaderRepository.Delete(FAQHeaderId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("FAQ Header Deleted Successfully.");
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

        public FAQHeader GetAFAQHeader(int FAQHeaderId)
        {
            try
            {

                var faqHeader = _iFAQHeaderRepository.GetAFAQHeader(FAQHeaderId);
                return faqHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<FAQHeader> GetAllFaqHeader()
        {
            try
            {

                var faqHeader = _iFAQHeaderRepository.GetAllFAQHeader();
                return faqHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
