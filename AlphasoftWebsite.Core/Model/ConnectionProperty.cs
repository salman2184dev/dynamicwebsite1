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
    
    public partial class ConnectionProperty
    {
        public int UserConnectionId { get; set; }
        public int UserId { get; set; }
        public string ConnectionId { get; set; }
        public bool ConnectionStatus { get; set; }
    
        public virtual ChatUser ChatUser { get; set; }
    }
}
