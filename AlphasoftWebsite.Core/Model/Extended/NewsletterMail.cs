using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.NewsletterMailMetadata))]
    public partial class NewsletterMail
    {
    }

    public class NewsletterMailMetadata
    {
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
