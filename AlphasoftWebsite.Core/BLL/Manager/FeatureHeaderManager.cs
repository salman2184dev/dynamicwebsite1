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
    public class FeatureHeaderManager : IFeatureHeaderManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IFeatureHeaderRepository _iFeatureHeaderRepository;

        public FeatureHeaderManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iFeatureHeaderRepository = new FeatureHeaderRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(FeatureHeader featureHeader)
        {
            var message = new Message();
            var ID = featureHeader.FeatureHeaderId;
            int result = _iFeatureHeaderRepository.AddOrEdit(featureHeader);
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

        public Message Delete(int featureHeaderId)
        {
            var message = new Message();
            try
            {

                int result = _iFeatureHeaderRepository.Delete(featureHeaderId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("featureHeader Deleted Successfully.");
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

        public IEnumerable<FeatureHeader> GetAllFeatureHeader()
        {

            try
            {

                var featureHeader = _iFeatureHeaderRepository.GetAllFeatureHeader();
                return featureHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FeatureHeader GetFeatureHeader(int featureHeaderId)
        {
            try
            {

                var featureHeader = _iFeatureHeaderRepository.GetAFeatureHeader(featureHeaderId);
                return featureHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
