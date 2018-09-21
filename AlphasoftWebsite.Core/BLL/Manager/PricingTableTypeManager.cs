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
    public class PricingTableTypeManager : IPricingTableTypeManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IPricingTableTypeRepository _iPricingTableTypeRepository;

        public PricingTableTypeManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iPricingTableTypeRepository = new PricingTableTypeRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(PricingTableType pricingTableType)
        {
            var message = new Message();
            var ID = pricingTableType.PricingTableTypeID;
            int result = _iPricingTableTypeRepository.AddOrEdit(pricingTableType);
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

        public Message Delete(int pricingTableTypeId)
        {
            var message = new Message();
            try
            {

                int result = _iPricingTableTypeRepository.Delete(pricingTableTypeId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("factorHeader Deleted Successfully.");
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

        public IEnumerable<PricingTableType> GetAllPricingTableType()
        {
            try
            {

                var pricingTableType = _iPricingTableTypeRepository.GetAllPricingTableType();
                return pricingTableType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PricingTableType GetAPricingTableType(int pricingTableTypeId)
        {
            try
            {

                var pricingTableType = _iPricingTableTypeRepository.GetAPricingTableType(pricingTableTypeId);
                return pricingTableType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
