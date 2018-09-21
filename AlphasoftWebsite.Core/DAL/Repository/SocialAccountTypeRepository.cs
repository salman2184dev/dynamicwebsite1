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
    public class SocialAccountTypeRepository : ISocialAccountTypeRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public SocialAccountTypeRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(SocialAccountType socialAccountType)
        {
            if (socialAccountType.SocialAccountTypeId == 0)
            {
                socialAccountType.CreatedDate = DateTime.Now;
                socialAccountType.UpdatedDate = DateTime.Now;
                socialAccountType.CreatedBy = 1;
                socialAccountType.UpdatedBy = 1;
                _dbContext.SocialAccountTypes.Add(socialAccountType);
            }
            else
            {
                socialAccountType.UpdatedBy = 1;
                socialAccountType.UpdatedDate = DateTime.Now;
                _dbContext.Entry(socialAccountType).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int socialAccountTypeId)
        {
            var socialAccountType = _dbContext.SocialAccountTypes.FirstOrDefault(x => x.SocialAccountTypeId == socialAccountTypeId);
            if (socialAccountType != null)
            {
                _dbContext.SocialAccountTypes.Remove(socialAccountType);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<SocialAccountType> GetAllSocialAccountType()
        {
            var socialAccountTypeList = _dbContext.SocialAccountTypes.Include(a => a.IconList).ToList();
            return socialAccountTypeList;
        }

        public SocialAccountType GetASocialAccountType(int socialAccountTypeId)
        {
            var socialAccountType = _dbContext.SocialAccountTypes.Include(a => a.IconList).FirstOrDefault(x => x.SocialAccountTypeId == socialAccountTypeId);
            return socialAccountType;
        }
    }
}
