using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IChatUserManager
    {
        Message CreateChatUser(ChatUser chatUser);
        IEnumerable<ChatUser> GetAllUsers();
        ChatUser GetAUser(string userName);
        int CheckExistingName(string userName);
    }
}
