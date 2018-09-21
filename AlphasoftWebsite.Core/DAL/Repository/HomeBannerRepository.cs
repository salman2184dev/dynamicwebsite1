using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class HomeBannerRepository : IHomeBannerRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public HomeBannerRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(HomeBanner homeBanner)
        {
            
            
            if (homeBanner.HomeBannerId == 0)
            {

                homeBanner.CreatedDate = DateTime.Now;
                homeBanner.UpdatedDate = DateTime.Now;
                homeBanner.CreatedBy = 1;
                homeBanner.UpdatedBy = 1;
                _dbContext.HomeBanners.Add(homeBanner);
            }
            else
            {
                homeBanner.UpdatedBy = 1;
                homeBanner.UpdatedDate = DateTime.Now;
                _dbContext.Entry(homeBanner).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int CheckAlreadyExist(HomeBanner homeBanner, bool isSave)
        {
            var serial= new List<HomeBanner>();
            if (homeBanner.HomeBannerId > 0)
            {
                serial = _dbContext.HomeBanners
                    .Where(a => a.SerialNo == homeBanner.SerialNo && a.HomeBannerId != homeBanner.HomeBannerId)
                    .ToList();
            }
            else
            {
                serial = _dbContext.HomeBanners
                    .Where(a => a.SerialNo == homeBanner.SerialNo)
                    .ToList();
            }
            var count = serial.Count;
            return count;
        }

        public int Delete(int homeBannerId)
        {
            var homeBanner = _dbContext.HomeBanners.FirstOrDefault(x => x.HomeBannerId == homeBannerId);
            if (homeBanner != null)
            {
                _dbContext.HomeBanners.Remove(homeBanner);
            }

            return _dbContext.SaveChanges();
        }

        public HomeBanner GetAHomeBanner(int homeBannerId)
        {
            var homeBanner = _dbContext.HomeBanners.FirstOrDefault(x => x.HomeBannerId == homeBannerId);
            return homeBanner;
        }

        public IEnumerable<HomeBanner> GetAllHomeBanner()
        {
            var homeBannerList = _dbContext.HomeBanners.ToList();
            return homeBannerList;
        }

        //public string GetHomeBannerImage(HomeBanner homeBanner, int homeBannerId)
        //{
        //    var imagestring = ConfigurationManager.AppSettings["HomeBannerImage"];

        //    var homebannerImage = _dbContext.HomeBanners.FirstOrDefault(x => x.HomeBannerImage == homeBanner.HomeBannerImage);
        //    return homebannerImage;
        //}
    }
}
