using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IOnlineUserFeedBackDetailManager
    {
        Message AddOrEdit(OnlineUserFeedBackDetail newsletterSubscriber);
        IEnumerable<OnlineUserFeedBackDetail> GetAllOnlineUserFeedBackDetail();
        Message Delete(int userFeedBackId);
        OnlineUserFeedBackDetail GetAnOnlineUserFeedBackDetail(int userFeedBackId);
    }
}
