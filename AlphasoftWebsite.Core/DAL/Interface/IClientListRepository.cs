using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
   public interface IClientListRepository
    {

        int AddOrEdit(ClientList clientList);
        IEnumerable<ClientList> GetAllClientList();
        int Delete(int clientId);
        ClientList GetAClientList(int clientId);
    }
}
