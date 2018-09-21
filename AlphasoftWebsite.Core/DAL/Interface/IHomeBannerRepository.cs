using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
     public interface IHomeBannerRepository
    {
        int AddOrEdit(HomeBanner homeBanner);
        IEnumerable<HomeBanner> GetAllHomeBanner();
        int Delete(int homeBannerId);
        HomeBanner GetAHomeBanner(int homeBannerId);
        int CheckAlreadyExist(HomeBanner homeBanner, bool isSave);
       // string GetHomeBannerImage(int homeBannerId);

    }
}
