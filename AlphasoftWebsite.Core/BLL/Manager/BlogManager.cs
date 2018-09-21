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
    public class BlogManager : IBlogManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IBlogRepository _iBlogRepository;

        public BlogManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iBlogRepository = new BlogRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(Blog blog)
        {
            var message = new Message();
            var ID = blog.BlogId;
            int result = _iBlogRepository.AddOrEdit(blog);
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

        public Message Delete(int blogId)
        {
            var message = new Message();
            try
            {

                int result = _iBlogRepository.Delete(blogId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("Blog Deleted Successfully.");
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

        public IEnumerable<Blog> GetAllBlog()
        {
            try
            {

                var blog = _iBlogRepository.GetAllBlog();
                return blog;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Blog GetAnBlog(int blogId)
        {
            try
            {

                var blog = _iBlogRepository.GetAnBlog(blogId);
                return blog;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
