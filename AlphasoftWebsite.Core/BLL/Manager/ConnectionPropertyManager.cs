using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.DAL.Repository;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Manager
{
    public class ConnectionPropertyManager : IConnectionPropertyManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IConnectionPropertiesRepository _iConnectionPropertiesRepository;

        public ConnectionPropertyManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iConnectionPropertiesRepository = new ConnectionPropertiesRepository(_AlphasoftWebsiteContext);
        }

        public Message CreateConnection(ConnectionProperty connection)
        {
            var message = new Message();
            try
            {
                var result = _iConnectionPropertiesRepository.CreateConnection(connection);
                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Connection Made Successfully");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Could not make a Connection!");
                }
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetInformationMessage(ex.Message);
            }

            return message;
        }

        public Message UpdateConnection(ConnectionProperty connection)
        {
            var message = new Message();
            try
            {
                var result = _iConnectionPropertiesRepository.UpdateConnection(connection);
                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Connection Made Successfully");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Could not make a Connection!");
                }
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetInformationMessage(ex.Message);
            }

            return message;
        }

        public ConnectionProperty GetConnectionStatus(int userConnectionId)
        {
            try
            {
                var connectionDetails = _iConnectionPropertiesRepository.GetCurrentConnectionStatus(userConnectionId);
                return connectionDetails;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public IEnumerable<ConnectionProperty> GetAllOnlineUser()
        {
            try
            {
                var onlineUsers = _iConnectionPropertiesRepository.GetAllOnlineUser();
                return onlineUsers;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public ConnectionProperty GetConnectionOnConnectionId(string connectionId)
        {
            try
            {
                var connectionDetails = _iConnectionPropertiesRepository.GetConnectionOnConnectionId(connectionId);
                return connectionDetails;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
    }
}
