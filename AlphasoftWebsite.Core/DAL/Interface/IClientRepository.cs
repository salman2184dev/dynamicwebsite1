using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IClientRepository
    {
        int AddOrEdit(Client client);
        IEnumerable<Client> GetAllClient();
        int Delete(int clientId);
        Client GetAClient(int clientId);
    }
}
