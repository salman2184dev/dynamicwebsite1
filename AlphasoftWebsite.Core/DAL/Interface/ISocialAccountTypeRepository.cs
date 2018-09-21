using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface ISocialAccountTypeRepository
    {
        int AddOrEdit(SocialAccountType socialAccountType);
        IEnumerable<SocialAccountType> GetAllSocialAccountType();
        int Delete(int socialAccountTypeId);
        SocialAccountType GetASocialAccountType(int socialAccountTypeId);
    }
}
