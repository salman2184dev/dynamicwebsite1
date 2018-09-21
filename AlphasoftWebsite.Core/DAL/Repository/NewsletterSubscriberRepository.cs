using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class NewsletterSubscriberRepository : INewsletterSubscriberRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public NewsletterSubscriberRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(NewsletterSubscriber newsletterSubscriber)
        {
            if (newsletterSubscriber.NewsletterSubscriberId==0)
            {
                newsletterSubscriber.MachineIP= HttpContext.Current.Request.UserHostAddress;
                newsletterSubscriber.SubscriptionDate=DateTime.Now;
                _dbContext.NewsletterSubscribers.Add(newsletterSubscriber);
            }
            else
            {
                newsletterSubscriber.MachineIP = HttpContext.Current.Request.UserHostAddress;
                newsletterSubscriber.SubscriptionDate = DateTime.Now;
                _dbContext.Entry(newsletterSubscriber).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int newsletterSubscriberId)
        {
            var newsletterSubscriber = _dbContext.NewsletterSubscribers.FirstOrDefault(x => x.NewsletterSubscriberId == newsletterSubscriberId);
            if (newsletterSubscriber != null)
            {
                _dbContext.NewsletterSubscribers.Remove(newsletterSubscriber);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<NewsletterSubscriber> GetAllNewsletterSubscriber()
        {
            var newsletterSubscriberList = _dbContext.NewsletterSubscribers.ToList();
            return newsletterSubscriberList;
        }

        public NewsletterSubscriber GetANewsletterSubscriber(int newsletterSubscriberId)
        {
            var newsletterSubscriber = _dbContext.NewsletterSubscribers.FirstOrDefault(x => x.NewsletterSubscriberId == newsletterSubscriberId);
            return newsletterSubscriber;
        }
    }
}
