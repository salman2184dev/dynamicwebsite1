//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlphasoftWebsite.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsletterMail
    {
        public int NewsletterMailId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachFile { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
