using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.BlogMetadata))]
    public partial class Blog
    {
              
    }
    public class BlogMetadata
    {
        [DataType(DataType.MultilineText)]
        public string BlogDescription { get; set; }
    }
}
