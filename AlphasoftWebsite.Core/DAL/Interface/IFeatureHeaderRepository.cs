using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IFeatureHeaderRepository
    {
        int AddOrEdit(FeatureHeader featureHeader);
        IEnumerable<FeatureHeader> GetAllFeatureHeader();
        int Delete(int featureHeaderId);
        FeatureHeader GetAFeatureHeader(int featureHeaderId);
    }
}
