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
    
    public partial class tbl_BaseMahdoodeh
    {
        public tbl_BaseMahdoodeh()
        {
            this.tbl_SaleZamin = new HashSet<tbl_SaleZamin>();
        }
    
        public int intIdMahdoodeh { get; set; }
        public string chrNameMahdoodeh { get; set; }
    
        public virtual ICollection<tbl_SaleZamin> tbl_SaleZamin { get; set; }
    }
}
