using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IFAQHeaderManager
    {
        Message AddOrEdit(FAQHeader faqHeader);
        IEnumerable<FAQHeader> GetAllFaqHeader();
        Message Delete(int FAQHeaderId);
        FAQHeader GetAFAQHeader(int FAQHeaderId);
    }
}
