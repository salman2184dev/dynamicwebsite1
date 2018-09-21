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
    public class NewsletterSubscriberManager : INewsletterSubscriberManager
    {

        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly INewsletterSubscriberRepository _iNewsletterSubscriberRepository;

        public NewsletterSubscriberManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iNewsletterSubscriberRepository = new NewsletterSubscriberRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(NewsletterSubscriber newsletterSubscriber)
        {
            var message = new Message();
            var ID = newsletterSubscriber.NewsletterSubscriberId;
            int result = _iNewsletterSubscriberRepository.AddOrEdit(newsletterSubscriber);
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

        public Message Delete(int newsletterSubscriberId)
        {
            var message = new Message();
            try
            {

                int result = _iNewsletterSubscriberRepository.Delete(newsletterSubscriberId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("News letter Subscriber Deleted Successfully.");
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

        public IEnumerable<NewsletterSubscriber> GetAllNewsletterSubscriber()
        {
            try
            {

                var newsletterSubscriber = _iNewsletterSubscriberRepository.GetAllNewsletterSubscriber();
                return newsletterSubscriber;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public NewsletterSubscriber GetANewsletterSubscriber(int newsletterSubscriberId)
        {
            try
            {

                var newsletterSubscriber = _iNewsletterSubscriberRepository.GetANewsletterSubscriber(newsletterSubscriberId);
                return newsletterSubscriber;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
