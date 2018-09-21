using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface ISoftwareRepository
    {
        int AddOrEdit(Software software);
        IEnumerable<Software> GetAllSoftware();
        int Delete(int softwareId);
        Software GetASoftware(int softwareId);

    }
}
