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
    public class BlogCategoryRepository : IBlogCategoryRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public BlogCategoryRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(BlogCategory blogCategory)
        {

            if (blogCategory.BlogCategoryId == 0)
            {
                blogCategory.CreatedDate = DateTime.Now;
                blogCategory.UpdatedDate = DateTime.Now;
                blogCategory.CreatedBy = 1;
                blogCategory.UpdatedBy = 1;
                _dbContext.BlogCategories.Add(blogCategory);
            }
            else
            {
                blogCategory.UpdatedBy = 1;
                blogCategory.UpdatedDate = DateTime.Now;
                _dbContext.Entry(blogCategory).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int blogCategoryId)
        {
            var blogCategory = _dbContext.BlogCategories.FirstOrDefault(x => x.BlogCategoryId == blogCategoryId);
            if (blogCategory != null)
            {
                _dbContext.BlogCategories.Remove(blogCategory);
            }

            return _dbContext.SaveChanges();
        }

        public BlogCategory GetABlogCategory(int blogCategoryId)
        {
            var blogCategory = _dbContext.BlogCategories.FirstOrDefault(x => x.BlogCategoryId == blogCategoryId);
            return blogCategory;
        }

        public IEnumerable<BlogCategory> GetAllBlogCategory()
        {
            var bloCategoriesList = _dbContext.BlogCategories.ToList();
            return bloCategoriesList;
        }
    }
}
