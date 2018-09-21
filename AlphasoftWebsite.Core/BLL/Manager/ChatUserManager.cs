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
    public class ChatUserManager : IChatUserManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IChatUserRepository _iChatUserRepository;

        public ChatUserManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iChatUserRepository = new ChatUserRepository(_AlphasoftWebsiteContext);
        }

        public Message CreateChatUser(ChatUser chatUser)
        {
            var message = new Message();
            try
            {
                var result = _iChatUserRepository.CreateUser(chatUser);
                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("User Created Successfully");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("User Creation Failled");
                }
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetInformationMessage(ex.Message);
            }

            return message;
        }

        public IEnumerable<ChatUser> GetAllUsers()
        {
            try
            {
                var userList = _iChatUserRepository.GetAllChatUser();
                return userList;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public ChatUser GetAUser(string userName)
        {
            try
            {
                var userInfo = _iChatUserRepository.GetAChatUser(userName);
                return userInfo;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public int CheckExistingName(string userName)
        {
            try
            {
                var exist = _iChatUserRepository.CheckExistingUserName(userName);
                return exist;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }
    }
}
