using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IServiceManager
    {
        Message AddOrEdit(Service service);
        IEnumerable<Service> GetAllService();
        Message Delete(int serviceId);
        Service GetAService(int serviceId);
    }
}
