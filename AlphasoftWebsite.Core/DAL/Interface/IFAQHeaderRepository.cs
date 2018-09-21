using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IFAQHeaderRepository
    {
        int AddOrEdit(FAQHeader faqHeader);
        IEnumerable<FAQHeader> GetAllFAQHeader();
        int Delete(int FAQHeaderId);
        FAQHeader GetAFAQHeader(int FAQHeaderId);
    }
}
