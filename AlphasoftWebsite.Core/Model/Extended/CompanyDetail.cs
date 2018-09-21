using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(CompanyDetailMetadata))]
    public partial class CompanyDetail
    {
        

        public class CompanyDetailMetadata
        {
            [AllowHtml]
            public string GoogleMapLocation { get; set; }
        }
    }
}
