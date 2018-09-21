using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ISoftwareCategoryManager
    {
        Message AddOrEdit(SoftwareCategory softwareCategory);
        IEnumerable<SoftwareCategory> GetAllSoftwareCategory();
        Message Delete(int softwareCategoryId);
        SoftwareCategory GetASoftwareCategory(int softwareCategoryId);
    }
}
