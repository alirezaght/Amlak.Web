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
    
    public partial class tbl_BasePool
    {
        public tbl_BasePool()
        {
            this.tbl_EjareAparteman = new HashSet<tbl_EjareAparteman>();
            this.tbl_EjareMostaghelat = new HashSet<tbl_EjareMostaghelat>();
            this.tbl_EjareVila = new HashSet<tbl_EjareVila>();
            this.tbl_SaleAparteman = new HashSet<tbl_SaleAparteman>();
            this.tbl_SaleMostaghelat = new HashSet<tbl_SaleMostaghelat>();
            this.tbl_SaleVila = new HashSet<tbl_SaleVila>();
        }
    
        public int intIdPool { get; set; }
        public string chrNamePool { get; set; }
    
        public virtual ICollection<tbl_EjareAparteman> tbl_EjareAparteman { get; set; }
        public virtual ICollection<tbl_EjareMostaghelat> tbl_EjareMostaghelat { get; set; }
        public virtual ICollection<tbl_EjareVila> tbl_EjareVila { get; set; }
        public virtual ICollection<tbl_SaleAparteman> tbl_SaleAparteman { get; set; }
        public virtual ICollection<tbl_SaleMostaghelat> tbl_SaleMostaghelat { get; set; }
        public virtual ICollection<tbl_SaleVila> tbl_SaleVila { get; set; }
    }
}