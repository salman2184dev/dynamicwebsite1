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
    public class ClientManager : IClientManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IClientRepository _iClientRepository;
        public ClientManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iClientRepository = new ClientRepository(_AlphasoftWebsiteContext);
        }
        public Message AddOrEdit(Client client)
        {


            var message = new Message();
            var ID = client.ClientID;
            int result = _iClientRepository.AddOrEdit(client);
            try
            {
                if (result > 0)
                {
                    if (Convert.ToInt32(ID) > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Updated Successfully!");
                    }
                    else
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Successful!");
                    }

                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Could not be submitted!");
                }
            }
            catch (Exception e)
            {
                message = Message.SetMessages.SetWarningMessage(e.Message.ToString());
            }

            return message;
        }

        public Message Delete(int clientId)
        {
            var message = new Message();
            try
            {

                int result = _iClientRepository.Delete(clientId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Client Deleted Successfully.");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Failed to Delete Data.");
                }

            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }

            return message;
        }

        public Client GetAClient(int clientId)
        {

            try
            {

                var client = _iClientRepository.GetAClient(clientId);
                return client;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Client> GetAllClient()
        {
            try
            {

                var client = _iClientRepository.GetAllClient();
                return client;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
