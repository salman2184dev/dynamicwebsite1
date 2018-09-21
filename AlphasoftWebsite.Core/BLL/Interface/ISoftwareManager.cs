using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ISoftwareManager
    {
        Message AddOrEdit(Software software);
        IEnumerable<Software> GetAllSoftware();
        Message Delete(int softwareId);
        Software GetASoftware(int softwareId);
    }
}
