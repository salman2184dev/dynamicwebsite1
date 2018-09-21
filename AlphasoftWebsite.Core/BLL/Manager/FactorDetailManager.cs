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
    public class FactorDetailManager : IFactorDetailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IFactorDetailsRepository _iFactorDetailRepository;

        public FactorDetailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iFactorDetailRepository = new FactorDetailsRepository(_AlphasoftWebsiteContext);
        }
        public Message AddOrEdit(FactorDetail factorDetail)
        {
            var message = new Message();
            var ID = factorDetail.FactorDetailId;
            int result = _iFactorDetailRepository.AddOrEdit(factorDetail);
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

        public Message Delete(int factorDetailId)
        {
            var message = new Message();
            try
            {

                int result = _iFactorDetailRepository.Delete(factorDetailId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("FactorDetail Deleted Successfully.");
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

        public FactorDetail GetAFactorDetail(int factorDetailId)
        {
            try
            {

                var factorDetail = _iFactorDetailRepository.GetAFactorDetail(factorDetailId);
                return factorDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<FactorDetail> GetAllFactorDetail()
        {
            try
            {

                var factorDetail = _iFactorDetailRepository.GetAllFactorDetail();
                return factorDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
