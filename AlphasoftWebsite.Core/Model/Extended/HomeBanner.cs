using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.HomeBannerMetadata))]
    public partial class HomeBanner
    {
    }
    public class HomeBannerMetadata
    {
        [DataType(DataType.MultilineText)]
        public string HomeBannerDescription { get; set; }
    }
}
