using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IServiceRepository
    {
        int AddOrEdit(Service service);
        IEnumerable<Service> GetAllService();
        int Delete(int serviceId);
        Service GetAService(int serviceId);
    }
}
