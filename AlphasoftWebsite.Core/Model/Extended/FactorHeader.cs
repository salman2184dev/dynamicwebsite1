using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.FactorHeaderMetadata))]
    public partial class FactorHeader
    {
    }
    public class FactorHeaderMetadata
    {
        [DataType(DataType.MultilineText)]
        public string FactorHeaderBody { get; set; }
    }
}
