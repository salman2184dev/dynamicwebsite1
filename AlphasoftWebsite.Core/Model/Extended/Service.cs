using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.ServiceMetadata))]
    public partial class Service
    {

    }

    public class ServiceMetadata
    {
        [DataType(DataType.MultilineText)]
        public string ServiceDescription { get; set; }
    }
}
