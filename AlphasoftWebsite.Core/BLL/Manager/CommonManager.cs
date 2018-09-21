using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.DAL.Repository;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.BLL.Manager
{
    public class CommonManager : ICommonManager
    {
        private readonly AlphasoftWebsiteContext _dbContext;
        private readonly ICommonRepository _iCommonRepository;
        public CommonManager()
        {
            _dbContext = new AlphasoftWebsiteContext();
            _iCommonRepository = new CommonRepository(_dbContext);
        }

        public IEnumerable<SelectListItem> GetAllBlogCategories(int? id)
        {
            try
            {
                var blogCategoriesList = _iCommonRepository.GetAllBlogCategories(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return blogCategoriesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllCompanyList(int? id)
        {
            try
            {
                var companyList = _iCommonRepository.GetAllCompanyList(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return companyList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllDesignations(int? id)
        {
            try
            {              
                var designationList = _iCommonRepository.GetAllDesignations(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return designationList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllIconList(int? id)
        {

            try
            {
                var iconList = _iCommonRepository.GetAllIconList(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return iconList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllProductCategories(int? id)
        {

            try
            {
                var productCategoriesList = _iCommonRepository.GetAllProductCategories(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return productCategoriesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllService(int? id)
        {

            try
            {
                var serviceList = _iCommonRepository.GetAllService(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return serviceList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllNewsLetterEmails(int? id)
        {
            try
            {
                var newletterEmailList = _iCommonRepository.GetAllNewsLetterEmails(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return newletterEmailList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllSocialAccountTypeList(int? id)
        {

            try
            {
                var socialAccountTypeList = _iCommonRepository.GetAllSocialAccountTypeList(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return socialAccountTypeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllSoftwareCategories(int? id)
        {

            try
            {
                var softwareCategoriesList = _iCommonRepository.GetAllSoftwareCategories(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return softwareCategoriesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllSmtpHosts(int? id)
        {
            try
            {
                var smtpHostList = _iCommonRepository.GetAllSmtpHosts(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return smtpHostList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllHostTypes(int? id)
        {
            try
            {
                var hostTypeList = _iCommonRepository.GetAllHostTypes(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return hostTypeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllPricingTableType(int? id)
        {
            try
            {
                var hostTypeList = _iCommonRepository.GetAllPricingTableType(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return hostTypeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SelectListItem> GetAllPricingDetailType(int? id)
        {
            try
            {
                var hostTypeList = _iCommonRepository.GetAllPricingDetailType(id).Select(
                    o => new SelectListItem
                    {
                        Value = o.Value,
                        Text = o.Text
                    }).ToList();
                return hostTypeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
