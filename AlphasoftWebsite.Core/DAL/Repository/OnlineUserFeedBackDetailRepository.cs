using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class OnlineUserFeedBackDetailRepository : IOnlineUserFeedBackDetailRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public OnlineUserFeedBackDetailRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(OnlineUserFeedBackDetail onlineUserFeedBackDetail)
        {

            if (onlineUserFeedBackDetail.UserFeedBackId == 0)
            {
                onlineUserFeedBackDetail.MachineIP = HttpContext.Current.Request.UserHostAddress;
                onlineUserFeedBackDetail.CreatedDate = DateTime.Now;
                _dbContext.OnlineUserFeedBackDetails.Add(onlineUserFeedBackDetail);
            }
            else
            {
                onlineUserFeedBackDetail.MachineIP = HttpContext.Current.Request.UserHostAddress;
                onlineUserFeedBackDetail.CreatedDate = DateTime.Now;
                _dbContext.Entry(onlineUserFeedBackDetail).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int userFeedBackId)
        {
            var onlineUserFeedBackDetail = _dbContext.OnlineUserFeedBackDetails.FirstOrDefault(x => x.UserFeedBackId == userFeedBackId);
            if (onlineUserFeedBackDetail != null)
            {
                _dbContext.OnlineUserFeedBackDetails.Remove(onlineUserFeedBackDetail);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<OnlineUserFeedBackDetail> GetAllOnlineUserFeedBackDetail()
        {
            var onlineUserFeedBackDetail = _dbContext.OnlineUserFeedBackDetails.ToList();
            return onlineUserFeedBackDetail;
        }

        public OnlineUserFeedBackDetail GetAnOnlineUserFeedBackDetail(int userFeedBackId)
        {
            var onlineUserFeedBackDetail = _dbContext.OnlineUserFeedBackDetails.FirstOrDefault(x => x.UserFeedBackId == userFeedBackId);
            return onlineUserFeedBackDetail;
        }
    }
}
