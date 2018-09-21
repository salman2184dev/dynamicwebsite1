using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{

    [MetadataType(typeof(Model.FAQMetadata))]
    public partial class FAQ
    {
    }
    public class FAQMetadata
    {
        [DataType(DataType.MultilineText)]
        public string FAQAnswer { get; set; }
    }
}
