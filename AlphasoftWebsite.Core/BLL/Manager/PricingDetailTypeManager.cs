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
    public class PricingDetailTypeManager : IPricingDetailTypeManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IPricingDetailTypeRepository _iPricingDetailTypeRepository;

        public PricingDetailTypeManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iPricingDetailTypeRepository = new PricingDetailTypeRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(PricingDetailType pricingDetailType)
        {
            var message = new Message();
            var ID = pricingDetailType.PricingDetailTypeID;
            int result = _iPricingDetailTypeRepository.AddOrEdit(pricingDetailType);
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

        public Message Delete(int pricingDetailTypeId)
        {
            var message = new Message();
            try
            {

                int result = _iPricingDetailTypeRepository.Delete(pricingDetailTypeId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Pricing Detail Type Deleted Successfully.");
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

        public IEnumerable<PricingDetailType> GetAllPricingDetailType()
        {
            try
            {

                var pricingDetailType = _iPricingDetailTypeRepository.GetAllPricingDetailType();
                return pricingDetailType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PricingDetailType GetAPricingDetailType(int pricingDetailTypeId)
        {
            try
            {

                var pricingDetailType = _iPricingDetailTypeRepository.GetAPricingDetailType(pricingDetailTypeId);
                return pricingDetailType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
