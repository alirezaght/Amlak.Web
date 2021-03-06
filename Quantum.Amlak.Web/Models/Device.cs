//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quantum.Amlak.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        public Device()
        {
            this.Transaction = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceIMEI { get; set; }
        public System.DateTime LastConnectedDate { get; set; }
        public string DeviceId { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
