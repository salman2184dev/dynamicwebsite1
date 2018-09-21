using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IConnectionPropertyManager
    {
        Message CreateConnection(ConnectionProperty connection);
        Message UpdateConnection(ConnectionProperty connection);
        ConnectionProperty GetConnectionStatus(int userConnectionId);
        IEnumerable<ConnectionProperty> GetAllOnlineUser();
        ConnectionProperty GetConnectionOnConnectionId(string connectionId);
    }
}
