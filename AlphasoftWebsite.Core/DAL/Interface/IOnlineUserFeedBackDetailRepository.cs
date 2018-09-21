using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IOnlineUserFeedBackDetailRepository
    {
        int AddOrEdit(OnlineUserFeedBackDetail onlineUserFeedBackDetail);
        IEnumerable<OnlineUserFeedBackDetail> GetAllOnlineUserFeedBackDetail();
        int Delete(int userFeedBackId);
        OnlineUserFeedBackDetail GetAnOnlineUserFeedBackDetail(int userFeedBackId);
    }
}
