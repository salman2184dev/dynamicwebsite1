using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class CompanyDetailManager : ICompanyDetailManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly ICompanyDetailRepository _iCompanyDetailRepository;

        public CompanyDetailManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iCompanyDetailRepository = new CompanyDetailRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(CompanyDetail companyDetail)
        {
            var message = new Message();
            var ID = companyDetail.CompanyId;
            int result = _iCompanyDetailRepository.AddOrEdit(companyDetail);
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

        public Message Delete(int companyId)
        {
            var message = new Message();
            try
            {
                try
                {
                    int result = _iCompanyDetailRepository.Delete(companyId);

                    if (result > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Company Detail Deleted Successfully.");
                    }
                    else
                    {
                        message = Message.SetMessages.SetErrorMessage("Failed to Delete Data.");
                    }
                }
                catch (SqlException ex)
                {
                    
                }
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }

            return message;
        }

        public CompanyDetail GetACompanyDetail(int companyId)
        {
            try
            {

                var productCategory = _iCompanyDetailRepository.GetACompanyDetail(companyId);
                return productCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<CompanyDetail> GetAllCompanyDetail()
        {
            try
            {

                var productCategory = _iCompanyDetailRepository.GetAllCompanyDetail();
                return productCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
