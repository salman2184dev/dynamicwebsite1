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
    public class BlogCategoryManager : IBlogCategoryManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;

        private readonly IBlogCategoryRepository _iBlogCategoryRepository;

        public BlogCategoryManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iBlogCategoryRepository = new BlogCategoryRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(BlogCategory blogCategory)
        {
            var message = new Message();
            var ID = blogCategory.BlogCategoryId;
            int result = _iBlogCategoryRepository.AddOrEdit(blogCategory);
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

        public Message Delete(int blogCategoryId)
        {
            var message = new Message();
            try
            {

                int result = _iBlogCategoryRepository.Delete(blogCategoryId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("BlogCategory Deleted Successfully.");
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

        public IEnumerable<BlogCategory> GetAllBlogCategory()
        {
            try
            {

                var blogCategory = _iBlogCategoryRepository.GetAllBlogCategory();
                return blogCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BlogCategory GetABlogCategory(int blogCategoryId)
        {
            try
            {

                var blogCategory = _iBlogCategoryRepository.GetABlogCategory(blogCategoryId);
                return blogCategory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
