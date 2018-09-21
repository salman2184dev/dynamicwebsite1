using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IServicePropertyRepository
    {
        int AddOrEdit(ServiceProperty serviceProperty);
        IEnumerable<ServiceProperty> GetAllServiceProperty();
        int Delete(int servicePropertyId);
        ServiceProperty GetAServiceProperty(int servicePropertyId);
    }
}
