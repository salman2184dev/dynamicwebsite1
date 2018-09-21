using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IFAQRepository
    {
        int AddOrEdit(FAQ FAQ);
        IEnumerable<FAQ> GetAllFAQs();
        int Delete(int FAQId);
        FAQ GetAnFAQ(int FAQId);
    }
}
