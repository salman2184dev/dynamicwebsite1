using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface INewsletterMailRepository
    {
        int AddOrEdit(NewsletterMail newsletterMail);
        IEnumerable<NewsletterMail> GetAllNewsletterMail();
        int Delete(int newsletterMailId);
        NewsletterMail GetANewsletterMail(int newsletterMailId);
    }
}
