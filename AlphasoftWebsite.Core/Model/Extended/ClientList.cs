using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.ClientListMetadata))]
    public partial class ClientList
    {
        
    }

    public partial class ClientListMetadata
    {
        [DataType(DataType.MultilineText)]
        public string ClientReview { get; set; }
    }
}
