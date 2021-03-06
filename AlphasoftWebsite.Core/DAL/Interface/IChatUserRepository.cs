﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IChatUserRepository
    {
        int CreateUser(ChatUser chatUser);
        ChatUser GetAChatUser(string userName);
        IEnumerable<ChatUser> GetAllChatUser();
        int CheckExistingUserName(string userName);
    }
}
