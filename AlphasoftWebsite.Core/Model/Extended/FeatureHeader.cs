using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.FeatureHeaderMetadata))]
    public  partial class FeatureHeader
    {
    }
    public class FeatureHeaderMetadata
    {

        [DataType(DataType.MultilineText)]
        public string FeatureHeaderBody { get; set; }
    }
}
