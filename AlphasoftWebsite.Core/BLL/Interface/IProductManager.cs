using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IProductManager
    {
        Message AddOrEdit(Product product);
        IEnumerable<Product> GetAllProduct();
        Message Delete(int productId);
        Product GetAnProduct(int productId);
    }
}
