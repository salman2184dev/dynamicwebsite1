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
    public class FeatureDetailManager : IFeatureDetailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IFeatureDetailRepository _iFeatureDetailRepository;

        public FeatureDetailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iFeatureDetailRepository = new FeatureDetailRepository(_AlphasoftWebsiteContext);
        }
        public Message AddOrEdit(FeatureDetail featureDetail)
        {
            var message = new Message();
            var ID = featureDetail.FeatureDetailId;
            int result = _iFeatureDetailRepository.AddOrEdit(featureDetail);
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

        public Message Delete(int featureDetailId)
        {
            var message = new Message();
            try
            {

                int result = _iFeatureDetailRepository.Delete(featureDetailId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("FeatureDetail Deleted Successfully.");
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

        public FeatureDetail GetAFeatureDetail(int featureDetailId)
        {
            try
            {

                var featureDetail = _iFeatureDetailRepository.GetAFeatureDetail(featureDetailId);
                return featureDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<FeatureDetail> GetAllFeatureDetail()
        {
            try
            {

                var featureDetail = _iFeatureDetailRepository.GetAllFeatureDetail();
                return featureDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
