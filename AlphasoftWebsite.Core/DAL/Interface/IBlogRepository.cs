using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IBlogRepository
    {
        int AddOrEdit(Blog blog);
        IEnumerable<Blog> GetAllBlog();
        int Delete(int blogId);
        Blog GetAnBlog(int blogId);
    }
}
