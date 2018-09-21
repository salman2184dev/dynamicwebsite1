using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IBlogCategoryRepository
    {
        int AddOrEdit(BlogCategory blogCategory);
        IEnumerable<BlogCategory> GetAllBlogCategory();
        int Delete(int blogCategoryId);
        BlogCategory GetABlogCategory(int blogCategoryId);
    }
}
