using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface ISoftwareCategoryRepository
    {
        int AddOrEdit(SoftwareCategory softwareCategory);
        IEnumerable<SoftwareCategory> GetAllSoftwareCategory();
        int Delete(int softwareCategoryId);
        SoftwareCategory GetAnSoftwareCategory(int softwareCategoryId);
    }
}
