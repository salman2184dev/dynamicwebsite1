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
    public class PricingDetailManager : IPricingDetailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IPricingDetailRepository _iPricingDetailRepository;

        public PricingDetailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iPricingDetailRepository = new PricingDetailRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(PricingDetail pricingDetail)
        {
            var message = new Message();
            var ID = pricingDetail.PricingDetailID;
            int result = _iPricingDetailRepository.AddOrEdit(pricingDetail);
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

        public Message Delete(int pricingDetailId)
        {
            var message = new Message();
            try
            {

                int result = _iPricingDetailRepository.Delete(pricingDetailId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Pricing Detail Deleted Successfully.");
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

        public IEnumerable<PricingDetail> GetAllPricingDetail()
        {
            try
            {

                var pricingDetail = _iPricingDetailRepository.GetAllPricingDetail();
                return pricingDetail;
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
                return null;
            }
        }

        public PricingDetail GetAPricingDetail(int pricingDetailId)
        {

            try
            {

                var pricingDetail = _iPricingDetailRepository.GetAPricingDetail(pricingDetailId);
                return pricingDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
