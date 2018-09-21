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
    public class ConnectionPropertiesRepository : IConnectionPropertiesRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public ConnectionPropertiesRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateConnection(ConnectionProperty connection)
        {
            if (connection != null)
            {
                _dbContext.ConnectionProperties.Add(connection);
            }

            return _dbContext.SaveChanges();
        }

        public int UpdateConnection(ConnectionProperty connection)
        {
            if (connection.ConnectionId != null)
            {
                _dbContext.Entry(connection).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public ConnectionProperty GetCurrentConnectionStatus(int userConnectionId)
        {
            var propertyDetails = _dbContext.ConnectionProperties.Include(x => x.ChatUser).FirstOrDefault(x => x.UserConnectionId == userConnectionId);
            return propertyDetails;
        }

        public IEnumerable<ConnectionProperty> GetAllOnlineUser()
        {
            var onlineUser = _dbContext.ConnectionProperties.Include(x => x.ChatUser).Where(x => x.ConnectionStatus == true).ToList();
            return onlineUser;
        }

        public ConnectionProperty GetConnectionOnConnectionId(string connectionId)
        {
            var propertyDetails = _dbContext.ConnectionProperties.Include(x => x.ChatUser).FirstOrDefault(x => x.ConnectionId == connectionId);
            return propertyDetails;
        }
    }
}
