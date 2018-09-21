using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
   public interface IHomeBannerManager
    {
        Message AddOrEdit(HomeBanner homeBanner);
        IEnumerable<HomeBanner> GetAllHomeBanner();
        Message Delete(int homeBannerId);
        HomeBanner GetAHomeBanner(int homeBannerId);
    }
}
