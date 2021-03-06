﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IClientListManager
    {
        Message AddOrEdit(ClientList clientList);
        IEnumerable<ClientList> GetAllClientList();
        Message Delete(int clientListId);
        ClientList GetAClientList(int clientListId);
    }
}
