using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.FactorDetailMetadata))]
    public partial class FactorDetail
    {
    }

    public class FactorDetailMetadata
    {
        [DataType(DataType.MultilineText)]
        public string FactorDetailDescription { get; set; }
    }
}
