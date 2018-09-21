using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IBlogCategoryManager
    {
        Message AddOrEdit(BlogCategory blogCategory);
        IEnumerable<BlogCategory> GetAllBlogCategory();
        Message Delete(int blogCategoryId);
        BlogCategory GetABlogCategory(int blogCategoryId);
    }
}
