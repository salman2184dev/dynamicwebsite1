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
    public class ProductCategoryManager : IProductCategoryManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly IProductCategoryRepository _iProductCategoryRepository;

        public ProductCategoryManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iProductCategoryRepository = new ProductCategoryRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(ProductCategory productCategory)
        {
            var message = new Message();
            var ID = productCategory.ProductCategoryId;
            int result = _iProductCategoryRepository.AddOrEdit(productCategory);
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

        public Message Delete(int productCategoryId)
        {
            var message = new Message();
            try
            {

                int result = _iProductCategoryRepository.Delete(productCategoryId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("ProductCategory Deleted Successfully.");
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

        public IEnumerable<ProductCategory> GetAllProductCategory()
        {
            try
            {

                var productCategory = _iProductCategoryRepository.GetAllProductCategory();
                return productCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ProductCategory GetAProductCategory(int productCategoryId)
        {
            try
            {

                var productCategory = _iProductCategoryRepository.GetAProductCategory(productCategoryId);
                return productCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
