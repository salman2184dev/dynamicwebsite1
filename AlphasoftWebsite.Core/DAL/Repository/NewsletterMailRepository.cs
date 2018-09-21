using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class NewsletterMailRepository: INewsletterMailRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public NewsletterMailRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(NewsletterMail newsletterMail)
        {
            if (newsletterMail.NewsletterMailId == 0)
            {
                newsletterMail.CreatedBy = "Ayesha";
                newsletterMail.CreatedDate = DateTime.Now;
                _dbContext.NewsletterMails.Add(newsletterMail);
            }
            else
            {
                newsletterMail.UpdatedBy = "Ayesha";
                newsletterMail.UpdatedDate = DateTime.Now;
                _dbContext.Entry(newsletterMail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int newsletterMailId)
        {
            var newsletterMail = _dbContext.NewsletterMails.FirstOrDefault(x => x.NewsletterMailId == newsletterMailId);
            if (newsletterMail != null)
            {
                _dbContext.NewsletterMails.Remove(newsletterMail);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<NewsletterMail> GetAllNewsletterMail()
        {
            var newsletterMailList = _dbContext.NewsletterMails.ToList();
            return newsletterMailList;
        }

        public NewsletterMail GetANewsletterMail(int newsletterMailId)
        {
            var newsletterMail = _dbContext.NewsletterMails.FirstOrDefault(x => x.NewsletterMailId == newsletterMailId);
            return newsletterMail;
        }
    }
}
