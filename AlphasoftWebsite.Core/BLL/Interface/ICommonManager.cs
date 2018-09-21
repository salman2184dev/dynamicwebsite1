using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ICommonManager
    {
        IEnumerable<SelectListItem> GetAllDesignations(int? id);
        IEnumerable<SelectListItem> GetAllProductCategories(int? id);
        IEnumerable<SelectListItem> GetAllBlogCategories(int? id);
        IEnumerable<SelectListItem> GetAllIconList(int? id);
        IEnumerable<SelectListItem> GetAllCompanyList(int? id);
        IEnumerable<SelectListItem> GetAllSocialAccountTypeList(int? id);
        IEnumerable<SelectListItem> GetAllSoftwareCategories(int? id);
        IEnumerable<SelectListItem> GetAllService(int? id);
        IEnumerable<SelectListItem> GetAllNewsLetterEmails(int? id);
        IEnumerable<SelectListItem> GetAllSmtpHosts(int? id);
        IEnumerable<SelectListItem> GetAllHostTypes(int? id);
        IEnumerable<SelectListItem> GetAllPricingTableType(int? id);
        IEnumerable<SelectListItem> GetAllPricingDetailType(int? id);
    }
}