using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class ChatUserRepository : IChatUserRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public ChatUserRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateUser(ChatUser chatUser)
        {
            if (chatUser != null)
            {
                _dbContext.ChatUsers.Add(chatUser);
            }
            return _dbContext.SaveChanges();
        }

        public ChatUser GetAChatUser(string userName)
        {
                var chatUser = _dbContext.ChatUsers.FirstOrDefault(x => x.ChatUserName == userName);
                return chatUser;
        }

        public IEnumerable<ChatUser> GetAllChatUser()
        {
            var userList = _dbContext.ChatUsers.ToList();
            return userList;
        }

        public int CheckExistingUserName(string userName)
        {
            var exist = _dbContext.ChatUsers.Count(x => x.ChatUserName == userName);
            return exist;
        }
    }
}
