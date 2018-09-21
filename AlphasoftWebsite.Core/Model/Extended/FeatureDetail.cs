using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.FeatureDetailMetadata))]
    public partial class FeatureDetail
    {
    }
    public class FeatureDetailMetadata
    {
        [DataType(DataType.MultilineText)]
        public string FeatureDetailDescription { get; set; }
    }
}
