using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IClientManager
    {
        Message AddOrEdit(Client client);
        IEnumerable<Client> GetAllClient();
        Message Delete(int clientId);
        Client GetAClient(int clientId);
    }
}
