using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ISocialAccountTypeManager
    {
        Message AddOrEdit(SocialAccountType socialAccountType);
        IEnumerable<SocialAccountType> GetAllSocialAccountType();
        Message Delete(int socialAccountTypeId);
        SocialAccountType GetASocialAccountType(int socialAccountTypeId);
    }
}
