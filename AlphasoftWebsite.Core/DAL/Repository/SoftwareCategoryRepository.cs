using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class SoftwareCategoryRepository : ISoftwareCategoryRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public SoftwareCategoryRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(SoftwareCategory softwareCategory)
        {
            if (softwareCategory.SoftwareCategoryId == 0)
            {
                softwareCategory.CreatedDate = DateTime.Now;
                softwareCategory.UpdatedDate = DateTime.Now;
                softwareCategory.CreatedBy = 1;
                softwareCategory.UpdatedBy = 1;
                _dbContext.SoftwareCategories.Add(softwareCategory);
            }
            else
            {
                softwareCategory.UpdatedBy = 1;
                softwareCategory.UpdatedDate = DateTime.Now;
                _dbContext.Entry(softwareCategory).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int softwareCategoryId)
        {
            var softwareCategory = _dbContext.SoftwareCategories.FirstOrDefault(x => x.SoftwareCategoryId == softwareCategoryId);
            if (softwareCategory != null)
            {
                _dbContext.SoftwareCategories.Remove(softwareCategory);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<SoftwareCategory> GetAllSoftwareCategory()
        {
            var softwareCategoryList = _dbContext.SoftwareCategories.ToList();
            return softwareCategoryList;
        }

        public SoftwareCategory GetAnSoftwareCategory(int softwareCategoryId)
        {
            var softwareCategory = _dbContext.SoftwareCategories.FirstOrDefault(x => x.SoftwareCategoryId == softwareCategoryId);
            return softwareCategory;
        }
    }
}
