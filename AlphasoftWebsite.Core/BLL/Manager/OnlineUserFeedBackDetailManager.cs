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
    public class OnlineUserFeedBackDetailManager : IOnlineUserFeedBackDetailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly IOnlineUserFeedBackDetailRepository _iOnlineUserFeedBackDetailRepository;

        public OnlineUserFeedBackDetailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iOnlineUserFeedBackDetailRepository = new OnlineUserFeedBackDetailRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(OnlineUserFeedBackDetail onlineUserFeedBackDetail)
        {
            var message = new Message();
            var ID = onlineUserFeedBackDetail.UserFeedBackId;
            int result = _iOnlineUserFeedBackDetailRepository.AddOrEdit(onlineUserFeedBackDetail);
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

        public Message Delete(int userFeedBackId)
        {
            var message = new Message();
            try
            {

                int result = _iOnlineUserFeedBackDetailRepository.Delete(userFeedBackId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("User Feed Back Deleted Successfully.");
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

        public IEnumerable<OnlineUserFeedBackDetail> GetAllOnlineUserFeedBackDetail()
        {
            try
            {

                var onlineUserFeedBackDetail = _iOnlineUserFeedBackDetailRepository.GetAllOnlineUserFeedBackDetail();
                return onlineUserFeedBackDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public OnlineUserFeedBackDetail GetAnOnlineUserFeedBackDetail(int userFeedBackId)
        {
            try
            {

                var onlineUserFeedBackDetail = _iOnlineUserFeedBackDetailRepository.GetAnOnlineUserFeedBackDetail(userFeedBackId);
                return onlineUserFeedBackDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
