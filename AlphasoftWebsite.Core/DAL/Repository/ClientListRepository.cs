using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class ClientListRepository : IClientListRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public ClientListRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(ClientList clientList)
        {
            if (clientList.ClientID == 0)
            {

                clientList.CreatedDate = DateTime.Now;
                clientList.UpdatedDate = DateTime.Now;
                clientList.CreatedBy = 1;
                clientList.UpdatedBy = 1;
                _dbContext.ClientLists.Add(clientList);
            }
            else
            {
                clientList.UpdatedBy = 1;
                clientList.UpdatedDate = DateTime.Now;
                _dbContext.Entry(clientList).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int clientListId)
        {
            var clientList = _dbContext.ClientLists.FirstOrDefault(x => x.ClientID == clientListId);
            if (clientList != null)
            {
                _dbContext.ClientLists.Remove(clientList);
            }

            return _dbContext.SaveChanges();
        }

        public ClientList GetAClientList(int clientListId)
        {
            var clientList = _dbContext.ClientLists.FirstOrDefault(x => x.ClientID == clientListId);
            return clientList;
        }

        public IEnumerable<ClientList> GetAllClientList()
        {
            var clientListList = _dbContext.ClientLists.ToList();
            return clientListList;
        }
    }
}
