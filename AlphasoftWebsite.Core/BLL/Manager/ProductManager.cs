using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.DAL.Repository;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IProductRepository _iProductRepository;

        public ProductManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iProductRepository = new ProductRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(Product product)
        {
            var message = new Message();
            var ID = product.ProductId;
            int result = _iProductRepository.AddOrEdit(product);
            try
            {
                if (result > 0)
                {
                    if (Convert.ToInt32(ID) > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Updated Successfully!");
                    }
                    else
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Successful!");
                    }

                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Could not be submitted!");
                }
            }
            catch (Exception e)
            {
                message = Message.SetMessages.SetWarningMessage(e.Message.ToString());
            }

            return message;
        }

        public Message Delete(int productId)
        {
            var message = new Message();
            try
            {

                int result = _iProductRepository.Delete(productId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Product Deleted Successfully.");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Failed to Delete Data.");
                }

            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }

            return message;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            try
            {

                var product = _iProductRepository.GetAllProduct();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product GetAnProduct(int productId)
        {
            try
            {

                var product = _iProductRepository.GetAnProduct(productId);
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
