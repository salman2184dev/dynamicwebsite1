using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IProductCategoryManager
    {
        Message AddOrEdit(ProductCategory productCategory);
        IEnumerable<ProductCategory> GetAllProductCategory();
        Message Delete(int productCategoryId);
        ProductCategory GetAProductCategory(int productCategoryId);
    }
}
