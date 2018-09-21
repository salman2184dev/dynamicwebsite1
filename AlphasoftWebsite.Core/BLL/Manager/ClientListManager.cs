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
    public class ClientListManager : IClientListManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IClientListRepository _iClientListRepository;

        public ClientListManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iClientListRepository = new ClientListRepository(_AlphasoftWebsiteContext);
        }
        public Message AddOrEdit(ClientList clientList)
        {
            var message = new Message();
            var ID = clientList.ClientID;
            int result = _iClientListRepository.AddOrEdit(clientList);
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

        public Message Delete(int clientListId)
        {
            var message = new Message();
            try
            {

                int result = _iClientListRepository.Delete(clientListId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("ClientList Deleted Successfully.");
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

        public ClientList GetAClientList(int clientListId)
        {
            try
            {

                var clientList = _iClientListRepository.GetAClientList(clientListId);
                return clientList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<ClientList> GetAllClientList()
        {
            try
            {

                var clientList = _iClientListRepository.GetAllClientList();
                return clientList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
