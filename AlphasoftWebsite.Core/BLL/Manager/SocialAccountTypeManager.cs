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
    public class SocialAccountTypeManager : ISocialAccountTypeManager
    {

        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly ISocialAccountTypeRepository _iSocialAccountTypeRepository;

        public SocialAccountTypeManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iSocialAccountTypeRepository = new SocialAccountTypeRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(SocialAccountType socialAccountType)
        {
            var message = new Message();
            var ID = socialAccountType.SocialAccountTypeId;
            int result = _iSocialAccountTypeRepository.AddOrEdit(socialAccountType);
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

        public Message Delete(int socialAccountTypeId)
        {
            var message = new Message();
            try
            {

                int result = _iSocialAccountTypeRepository.Delete(socialAccountTypeId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Social Account Type Deleted Successfully.");
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

        public IEnumerable<SocialAccountType> GetAllSocialAccountType()
        {
            try
            {

                var socialAccountType = _iSocialAccountTypeRepository.GetAllSocialAccountType();
                return socialAccountType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SocialAccountType GetASocialAccountType(int socialAccountTypeId)
        {
            try
            {

                var socialAccountType = _iSocialAccountTypeRepository.GetASocialAccountType(socialAccountTypeId);
                return socialAccountType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
