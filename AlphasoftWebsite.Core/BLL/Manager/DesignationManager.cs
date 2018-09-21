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
    public class DesignationManager : IDesignationManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IDesignationRepository _iDesignationRepository;

        public DesignationManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iDesignationRepository = new DesignationRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(Designation designation)
        {
            var message = new Message();
            var ID = designation.DesignationId;
            int result = _iDesignationRepository.AddOrEdit(designation);
            try
            {
                if (result > 0)
                {
                    if (Convert.ToInt32(ID) > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Updated Successful!");
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

        public IEnumerable<Designation> GetAllDesignations()
        {
            try
            {

                var designations = _iDesignationRepository.GetAllDesignations();
                return designations;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Message Delete(int designationId)
        {
            var message = new Message();
            try
            {

                int result = _iDesignationRepository.Delete(designationId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Designation Deleted Successfully.");
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

        public Designation GetADesignation(int designationId)
        {
            try
            {

                var designation = _iDesignationRepository.GetADesignation(designationId);
                return designation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
