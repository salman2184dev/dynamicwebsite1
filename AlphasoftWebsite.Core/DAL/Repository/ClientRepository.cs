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
    public class ClientRepository : IClientRepository
    {

        public static AlphasoftWebsiteContext _dbContext;

        public ClientRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(Client client)
        {
            if (client.ClientID == 0)
            {

                client.CreatedDate = DateTime.Now;
                client.UpdatedDate = DateTime.Now;
                client.CreatedBy = 1;
                client.UpdatedBy = 1;
                _dbContext.Clients.Add(client);
            }
            else
            {
                client.UpdatedBy = 1;
                client.UpdatedDate = DateTime.Now;
                _dbContext.Entry(client).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int clientId)
        {
            var client = _dbContext.Clients.FirstOrDefault(x => x.ClientID == clientId);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
            }

            return _dbContext.SaveChanges();
        }

        public Client GetAClient(int clientId)
        {
            var client = _dbContext.Clients.FirstOrDefault(x => x.ClientID == clientId);
            return client;
        }

        public IEnumerable<Client> GetAllClient()
        {
            var clientList = _dbContext.Clients.ToList();
            return clientList;
        }
    }
}
