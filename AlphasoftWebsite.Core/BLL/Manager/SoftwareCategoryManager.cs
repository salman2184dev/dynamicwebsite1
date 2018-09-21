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
    public class SoftwareCategoryManager : ISoftwareCategoryManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly ISoftwareCategoryRepository _iSoftwareCategoryRepository;

        public SoftwareCategoryManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iSoftwareCategoryRepository = new SoftwareCategoryRepository(_AlphasoftWebsiteContext);
        }
        public Message AddOrEdit(SoftwareCategory softwareCategory)
        {
            var message = new Message();
            var ID = softwareCategory.SoftwareCategoryId;
            int result = _iSoftwareCategoryRepository.AddOrEdit(softwareCategory);
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

        public Message Delete(int softwareCategoryId)
        {
            var message = new Message();
            try
            {

                int result = _iSoftwareCategoryRepository.Delete(softwareCategoryId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Software Category Deleted Successfully.");
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

        public IEnumerable<SoftwareCategory> GetAllSoftwareCategory()
        {
            try
            {

                var softwareCategoryList = _iSoftwareCategoryRepository.GetAllSoftwareCategory();
                return softwareCategoryList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SoftwareCategory GetASoftwareCategory(int softwareCategoryId)
        {
            try
            {

                var softwareCategory = _iSoftwareCategoryRepository.GetAnSoftwareCategory(softwareCategoryId);
                return softwareCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
