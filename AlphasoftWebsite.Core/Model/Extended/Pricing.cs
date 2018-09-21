using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
   [MetadataType(typeof(PricingMetadata))]
   public partial class Pricing
   {

   }

    public partial class PricingMetadata
    {
        [DataType(DataType.MultilineText)]
        public string PricingBody { get; set; }
    }
}
