using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface INewsletterSubscriberRepository
    {
        int AddOrEdit(NewsletterSubscriber newsletterSubscriber);
        IEnumerable<NewsletterSubscriber> GetAllNewsletterSubscriber();
        int Delete(int newsletterSubscriberId);
        NewsletterSubscriber GetANewsletterSubscriber(int newsletterSubscriberId);
    }
}
