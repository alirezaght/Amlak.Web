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
    
    public partial class tbl_BaseSanad
    {
        public tbl_BaseSanad()
        {
            this.tbl_SaleAparteman = new HashSet<tbl_SaleAparteman>();
            this.tbl_SaleMaghaze = new HashSet<tbl_SaleMaghaze>();
            this.tbl_SaleMostaghelat = new HashSet<tbl_SaleMostaghelat>();
            this.tbl_SaleVila = new HashSet<tbl_SaleVila>();
            this.tbl_SaleZamin = new HashSet<tbl_SaleZamin>();
        }
    
        public int intIdSanad { get; set; }
        public string chrNameSanad { get; set; }
    
        public virtual ICollection<tbl_SaleAparteman> tbl_SaleAparteman { get; set; }
        public virtual ICollection<tbl_SaleMaghaze> tbl_SaleMaghaze { get; set; }
        public virtual ICollection<tbl_SaleMostaghelat> tbl_SaleMostaghelat { get; set; }
        public virtual ICollection<tbl_SaleVila> tbl_SaleVila { get; set; }
        public virtual ICollection<tbl_SaleZamin> tbl_SaleZamin { get; set; }
    }
}
