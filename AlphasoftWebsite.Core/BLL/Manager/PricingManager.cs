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
    public class PricingManager : IPricingManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IPricingRepository _iPricingRepository;

        public PricingManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iPricingRepository = new PricingRepository(_AlphasoftWebsiteContext);
        }


        public Message AddOrEdit(Pricing pricing)
        {
            var message = new Message();
            var ID = pricing.PricingID;
            int result = _iPricingRepository.AddOrEdit(pricing);
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

        public Message Delete(int pricingId)
        {
            var message = new Message();
            try
            {

                int result = _iPricingRepository.Delete(pricingId);

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

        public IEnumerable<Pricing> GetAllPricing()
        {
            try
            {

                var pricing = _iPricingRepository.GetAllPricing();
                return pricing;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Pricing GetAPricing(int pricingId)
        {

            try
            {

                var pricing = _iPricingRepository.GetAPricing(pricingId);
                return pricing;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
