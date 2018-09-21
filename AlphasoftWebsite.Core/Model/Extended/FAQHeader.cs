using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.FAQHeaderMetadata))]
    public partial class FAQHeader
    {
    }

    public class FAQHeaderMetadata
    {
        [DataType(DataType.MultilineText)]
        public string FAQHeaderBody { get; set; }
    }
}
