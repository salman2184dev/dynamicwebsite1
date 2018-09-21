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
    public class NewsletterMailManager: INewsletterMailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly INewsletterMailRepository _iNewsletterMailRepository;

        public NewsletterMailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iNewsletterMailRepository = new NewsletterMailRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(NewsletterMail newsletterMail)
        {
            var message = new Message();
            var ID = newsletterMail.NewsletterMailId;
            int result = _iNewsletterMailRepository.AddOrEdit(newsletterMail);
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

        public Message Delete(int newsletterMailId)
        {
            var message = new Message();
            try
            {

                int result = _iNewsletterMailRepository.Delete(newsletterMailId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("News letter Mail Deleted Successfully.");
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

        public IEnumerable<NewsletterMail> GetAllNewsletterMail()
        {
            try
            {

                var newsletterMail = _iNewsletterMailRepository.GetAllNewsletterMail();
                return newsletterMail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public NewsletterMail GetANewsletterMail(int newsletterMailId)
        {
            try
            {

                var newsletterMail = _iNewsletterMailRepository.GetANewsletterMail(newsletterMailId);
                return newsletterMail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
