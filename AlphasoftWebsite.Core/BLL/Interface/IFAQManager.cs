using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IFAQManager
    {
        Message AddOrEdit(FAQ FAQ);
        IEnumerable<FAQ> GetAllFAQs();
        Message Delete(int FAQId);
        FAQ GetAnFAQ(int FAQId);
    }
}
