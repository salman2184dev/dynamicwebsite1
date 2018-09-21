﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphasoftWebsite.Core.Model
{
    [MetadataType(typeof(Model.ClientMetaData))]
    public  partial class Client
    {

    }
    public  class ClientMetaData
    {
        [DataType(DataType.MultilineText)]
        public string ClientBody { get; set; }
    }
}
