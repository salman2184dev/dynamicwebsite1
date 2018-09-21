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
    public class HomeBannerManager : IHomeBannerManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IHomeBannerRepository _iHomeBannerRepository;

        public HomeBannerManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iHomeBannerRepository = new HomeBannerRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(HomeBanner homeBanner)
        {
            var message = new Message();
            var ID = homeBanner.HomeBannerId;
            int exist = _iHomeBannerRepository.CheckAlreadyExist(homeBanner, true);
            try
            {
                if (exist < 1)
                {
                    int result = _iHomeBannerRepository.AddOrEdit(homeBanner);
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
                else
                {
                    message = Message.SetMessages.SetWarningMessage("Serial No already exists!");
                }

            }

            catch (Exception e)
            {
                message = Message.SetMessages.SetWarningMessage(e.Message.ToString());
            }

            return message;
        }
    

    public Message Delete(int homeBannerId)
        {
            var message = new Message();
            try
            {

                int result = _iHomeBannerRepository.Delete(homeBannerId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("HomeBanner Deleted Successfully.");
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

        public IEnumerable<HomeBanner> GetAllHomeBanner()
        {
            try
            {

                var homeBanner = _iHomeBannerRepository.GetAllHomeBanner();
                return homeBanner;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HomeBanner GetAHomeBanner(int homeBannerId)
        {
            try
            {

                var homeBanner = _iHomeBannerRepository.GetAHomeBanner(homeBannerId);
                return homeBanner;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
