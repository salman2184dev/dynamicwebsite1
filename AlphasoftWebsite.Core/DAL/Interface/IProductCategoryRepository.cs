using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
     public interface IProductCategoryRepository
    {

        int AddOrEdit(ProductCategory productCategory);
        IEnumerable<ProductCategory> GetAllProductCategory();
        int Delete(int productCategoryId);
        ProductCategory GetAProductCategory(int productCategoryId);
    }
}
