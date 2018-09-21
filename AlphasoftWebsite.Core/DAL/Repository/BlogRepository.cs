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
    public class BlogRepository : IBlogRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public BlogRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(Blog blog)
        {
            if (blog.BlogId == 0)
            {
                blog.CreatedDate = DateTime.Now;
                blog.UpdatedDate = DateTime.Now;
                blog.CreatedBy = 1;
                blog.UpdatedBy = 1;
                _dbContext.Blogs.Add(blog);
            }
            else
            {
                blog.UpdatedBy = 1;
                blog.UpdatedDate = DateTime.Now;
                _dbContext.Entry(blog).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int blogId)
        {
            var blog = _dbContext.Blogs.FirstOrDefault(x => x.BlogId == blogId);
            if (blog != null)
            {
                _dbContext.Blogs.Remove(blog);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Blog> GetAllBlog()
        {

            var blogList = _dbContext.Blogs.Include(a => a.BlogCategory).ToList();
            return blogList;
        }

        public Blog GetAnBlog(int blogId)
        {
            var blog = _dbContext.Blogs.Include(a => a.BlogCategory).FirstOrDefault(x => x.BlogId == blogId);
            return blog;
        }
    }
}
