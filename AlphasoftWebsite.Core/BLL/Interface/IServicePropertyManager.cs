using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IServicePropertyManager
    {
        Message AddOrEdit(ServiceProperty serviceProperty);
        IEnumerable<ServiceProperty> GetAllServiceProperty();
        Message Delete(int servicePropertyId);
        ServiceProperty GetAServiceProperty(int servicePropertyId);
    }
}
