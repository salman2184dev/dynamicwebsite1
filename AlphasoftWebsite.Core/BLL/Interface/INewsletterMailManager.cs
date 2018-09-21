using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface INewsletterMailManager
    {
        Message AddOrEdit(NewsletterMail newsletterMail);
        IEnumerable<NewsletterMail> GetAllNewsletterMail();
        Message Delete(int newsletterMailId);
        NewsletterMail GetANewsletterMail(int newsletterMailId);
    }
}
