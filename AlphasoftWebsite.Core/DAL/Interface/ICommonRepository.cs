using System.Collections;
using System.Collections.Generic;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface ICommonRepository
    {
        IEnumerable<DropDown> GetAllDesignations(int? id);
        IEnumerable<DropDown> GetAllProductCategories(int? id);
        IEnumerable<DropDown> GetAllBlogCategories(int? id);
        IEnumerable<DropDown> GetAllIconList(int? id);
        IEnumerable<DropDown> GetAllCompanyList(int? id);
        IEnumerable<DropDown> GetAllSocialAccountTypeList(int? id);
        IEnumerable<DropDown> GetAllSoftwareCategories(int? id);
        IEnumerable<DropDown> GetAllService(int? id);
        IEnumerable<DropDown> GetAllNewsLetterEmails(int? id);
        IEnumerable<DropDown> GetAllSmtpHosts(int? id);
        IEnumerable<DropDown> GetAllHostTypes(int? id);
        IEnumerable<DropDown> GetAllPricingDetailType(int? id);
        IEnumerable<DropDown> GetAllPricingTableType(int? id);
    }
}
