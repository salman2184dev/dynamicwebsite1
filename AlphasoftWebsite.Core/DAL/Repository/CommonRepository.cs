using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;


namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class CommonRepository : ICommonRepository
    {
        public static AlphasoftWebsiteContext _dbContext;
        public CommonRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DropDown> GetAllBlogCategories(int? id)
        {
            var blogCategoriesList = _dbContext.BlogCategories.Where(a => a.BlogCategoryId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.BlogCategoryId,
                Text = a.BlogCategoryName
            }).ToList();
            //DataTable data = Utility.DataTable.GetDataTable(designationList);

            //var designationList = _dbContext.Database.SqlQuery<DropDown>(" Select CAST(DesignationId as nchar(10)) as Value, DesignationName as Text from Designations").ToList();
            DataTable data = Utility.DataTable.GetDataTable(blogCategoriesList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllCompanyList(int? id)
        {
            var companyList = _dbContext.CompanyDetails.Where(a => a.CompanyId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.CompanyId,
                Text = a.CompanyName
            }).ToList();
            //DataTable data = Utility.DataTable.GetDataTable(designationList);

            //var designationList = _dbContext.Database.SqlQuery<DropDown>(" Select CAST(DesignationId as nchar(10)) as Value, DesignationName as Text from Designations").ToList();
            DataTable data = Utility.DataTable.GetDataTable(companyList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllDesignations(int? id)
        {
            var designationList = _dbContext.Designations.Where(a => a.DesignationId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.DesignationId,
                Text = a.DesignationName
            }).ToList();
            //DataTable data = Utility.DataTable.GetDataTable(designationList);

            //var designationList = _dbContext.Database.SqlQuery<DropDown>(" Select CAST(DesignationId as nchar(10)) as Value, DesignationName as Text from Designations").ToList();
            DataTable data = Utility.DataTable.GetDataTable(designationList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllIconList(int? id)
        {
            var iconList = _dbContext.IconLists.Where(a => a.IconId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.IconId,
                Text = a.IconName
            }).ToList();
           
            DataTable data = Utility.DataTable.GetDataTable(iconList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllProductCategories(int? id)
        {
            var productCategoriesList = _dbContext.ProductCategories.Where(a => a.ProductCategoryId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.ProductCategoryId,
                Text = a.ProductCategoryName
            }).ToList();
            //DataTable data = Utility.DataTable.GetDataTable(designationList);

            //var designationList = _dbContext.Database.SqlQuery<DropDown>(" Select CAST(DesignationId as nchar(10)) as Value, DesignationName as Text from Designations").ToList();
            DataTable data = Utility.DataTable.GetDataTable(productCategoriesList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllService(int? id)
        {
            var serviceList = _dbContext.Services.Where(a => a.ServiceId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.ServiceId,
                Text = a.ServiceName
            }).ToList();

            DataTable data = Utility.DataTable.GetDataTable(serviceList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllNewsLetterEmails(int? id)
        {
            var newsletterMailList = _dbContext.NewsletterMails.Where(a => a.NewsletterMailId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.NewsletterMailId,
                Text = a.Subject
            }).ToList();

            DataTable data = Utility.DataTable.GetDataTable(newsletterMailList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllSocialAccountTypeList(int? id)
        {
            var socialAccountTypeList = _dbContext.SocialAccountTypes.Where(a => a.SocialAccountTypeId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.SocialAccountTypeId,
                Text = a.SocialAccountName
            }).ToList();
          
            DataTable data = Utility.DataTable.GetDataTable(socialAccountTypeList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllSoftwareCategories(int? id)
        {

            var softwareCategoriesList = _dbContext.SoftwareCategories.Where(a => a.SoftwareCategoryId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.SoftwareCategoryId,
                Text = a.SoftwareCategoryName
            }).ToList();
           
            DataTable data = Utility.DataTable.GetDataTable(softwareCategoriesList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllSmtpHosts(int? id)
        {
            var smtpHostList = _dbContext.SmtpHosts.Where(a => a.SmtpHostId == id || id == null || id.ToString() == "").Include(a=>a.HostType).Select(a => new
            {
                Value = a.SmtpHostId,
                Text = a.HostType.HostTypeName
            }).ToList();

            DataTable data = Utility.DataTable.GetDataTable(smtpHostList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllHostTypes(int? id)
        {
            var hostTypeList = _dbContext.HostTypes.Where(a => a.HostTypeId == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.HostTypeId,
                Text = a.HostTypeName
            }).ToList();

            DataTable data = Utility.DataTable.GetDataTable(hostTypeList);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllPricingDetailType(int? id)
        {
            var pricingDetailType = _dbContext.PricingDetailTypes.Where(a => a.PricingDetailTypeID == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.PricingDetailTypeID,
                Text = a.PricingDetailTypeName
            }).ToList();

            DataTable data = Utility.DataTable.GetDataTable(pricingDetailType);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }

        public IEnumerable<DropDown> GetAllPricingTableType(int? id)
        {
            var pricingTableType = _dbContext.PricingTableTypes.Where(a => a.PricingTableTypeID == id || id == null || id.ToString() == "").Select(a => new
            {
                Value = a.PricingTableTypeID,
                Text = a.PricingTableTypeName
            }).ToList();

            DataTable data = Utility.DataTable.GetDataTable(pricingTableType);

            return (from DataRow row in data.Rows select DropDown.ConvertToModel(row));
        }
    }
}
