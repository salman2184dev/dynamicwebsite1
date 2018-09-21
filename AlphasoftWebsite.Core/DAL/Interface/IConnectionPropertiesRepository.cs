using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IConnectionPropertiesRepository
    {
        int CreateConnection(ConnectionProperty connection);
        int UpdateConnection(ConnectionProperty connection);
        ConnectionProperty GetCurrentConnectionStatus(int userConnectionId);
        IEnumerable<ConnectionProperty> GetAllOnlineUser();
        ConnectionProperty GetConnectionOnConnectionId(string connectionId);
    }
}
