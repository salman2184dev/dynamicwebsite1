using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.SoftwareMetadata))]
    public partial class Software
    {
    }

    public class SoftwareMetadata
    {
        [DataType(DataType.MultilineText)]
        public string SoftwareDetails { get; set; }
    }
}
