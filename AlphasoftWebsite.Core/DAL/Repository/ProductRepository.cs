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
    public class ProductRepository : IProductRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public ProductRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(Product product)
        {
            if (product.ProductId == 0)
            {
                product.CreatedDate = DateTime.Now;
                product.UpdatedDate = DateTime.Now;
                product.CreatedBy = 1;
                product.UpdatedBy = 1;
                _dbContext.Products.Add(product);
            }
            else
            {
                product.UpdatedBy = 1;
                product.UpdatedDate = DateTime.Now;
                _dbContext.Entry(product).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int productId)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProduct()
        {

            var productList = _dbContext.Products.Include(a => a.ProductCategory).ToList();
            return productList;
        }

        public Product GetAnProduct(int productId)
        {
            var product = _dbContext.Products.Include(a => a.ProductCategory).FirstOrDefault(x => x.ProductId == productId);
            return product;
        }
    }
}
