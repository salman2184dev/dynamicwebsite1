using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.ProductMetadata))]
    public  partial class Product
    {
        
    }
    public class ProductMetadata
    {
        [DataType(DataType.MultilineText)]
        public string ProductDetails { get; set; }
    }
}
