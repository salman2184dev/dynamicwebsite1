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
     public class ProductCategoryRepository : IProductCategoryRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public ProductCategoryRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductCategory> GetAllProductCategory()
        {
            var productCategoryList = _dbContext.ProductCategories.ToList();
            return productCategoryList;
        }

        public int AddOrEdit(ProductCategory productCategory)
        {
            if (productCategory.ProductCategoryId == 0)
            {
                productCategory.CreatedDate = DateTime.Now;
                productCategory.UpdatedDate = DateTime.Now;
                productCategory.CreatedBy = 1;
                productCategory.UpdatedBy = 1;
                _dbContext.ProductCategories.Add(productCategory);
            }
            else
            {
                productCategory.UpdatedBy = 1;
                productCategory.UpdatedDate = DateTime.Now;
                _dbContext.Entry(productCategory).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int productCategoryId)
        {
            var productCategory = _dbContext.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == productCategoryId);
            if (productCategory != null)
            {
                _dbContext.ProductCategories.Remove(productCategory);
            }

            return _dbContext.SaveChanges();
            
        }

        public ProductCategory GetAProductCategory(int productCategoryId)
        {
            var productCategory = _dbContext.ProductCategories.FirstOrDefault(x => x.ProductCategoryId == productCategoryId);
            return productCategory;
        }
    }
}
