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
    public class CompanySocialAccountDetailManager: ICompanySocialAccountDetailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly ICompanySocialAccountDetailRepository _iCompanySocialAccountDetailRepository;

        public CompanySocialAccountDetailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iCompanySocialAccountDetailRepository = new CompanySocialAccountDetailRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(CompanySocialAccountDetail companySocialAccountDetail)
        {
            var message = new Message();
            var ID = companySocialAccountDetail.CompanySocialAccountDetailId;
            int result = _iCompanySocialAccountDetailRepository.AddOrEdit(companySocialAccountDetail);
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

        public Message Delete(int companySocialAccountDetailId)
        {
            var message = new Message();
            try
            {

                int result = _iCompanySocialAccountDetailRepository.Delete(companySocialAccountDetailId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Company Social Account Detail Deleted Successfully.");
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

      

        public IEnumerable<CompanySocialAccountDetail> GetAllCompanySocialAccountDetail()
        {
            try
            {

                var companySocialAccountDetail = _iCompanySocialAccountDetailRepository.GetAllCompanySocialAccountDetail();
                return companySocialAccountDetail;
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
                return null;
            }
        }

        public CompanySocialAccountDetail GetACompanySocialAccountDetail(int companySocialAccountDetailId)
        {
            try
            {

                var companySocialAccountDetail = _iCompanySocialAccountDetailRepository.GetACompanySocialAccountDetail(companySocialAccountDetailId);
                return companySocialAccountDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
