using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IProductRepository
    {
        int AddOrEdit(Product product);
        IEnumerable<Product> GetAllProduct();
        int Delete(int productId);
        Product GetAnProduct(int productId);

    }
}
