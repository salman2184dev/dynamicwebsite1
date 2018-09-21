using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface INewsletterSubscriberManager
    {
        Message AddOrEdit(NewsletterSubscriber newsletterSubscriber);
        IEnumerable<NewsletterSubscriber> GetAllNewsletterSubscriber();
        Message Delete(int newsletterSubscriberId);
        NewsletterSubscriber GetANewsletterSubscriber(int newsletterSubscriberId);
    }
}
