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
    
    public partial class tbl_BaseKaf
    {
        public tbl_BaseKaf()
        {
            this.tbl_DetailEjareMostaghelat = new HashSet<tbl_DetailEjareMostaghelat>();
            this.tbl_DetailSaleMostaghelat = new HashSet<tbl_DetailSaleMostaghelat>();
            this.tbl_EjareAparteman = new HashSet<tbl_EjareAparteman>();
            this.tbl_EjareMaghaze = new HashSet<tbl_EjareMaghaze>();
            this.tbl_EjareVila = new HashSet<tbl_EjareVila>();
            this.tbl_SaleAparteman = new HashSet<tbl_SaleAparteman>();
            this.tbl_SaleMaghaze = new HashSet<tbl_SaleMaghaze>();
            this.tbl_SaleVila = new HashSet<tbl_SaleVila>();
        }
    
        public int intIdKaf { get; set; }
        public string chrNameKaf { get; set; }
    
        public virtual ICollection<tbl_DetailEjareMostaghelat> tbl_DetailEjareMostaghelat { get; set; }
        public virtual ICollection<tbl_DetailSaleMostaghelat> tbl_DetailSaleMostaghelat { get; set; }
        public virtual ICollection<tbl_EjareAparteman> tbl_EjareAparteman { get; set; }
        public virtual ICollection<tbl_EjareMaghaze> tbl_EjareMaghaze { get; set; }
        public virtual ICollection<tbl_EjareVila> tbl_EjareVila { get; set; }
        public virtual ICollection<tbl_SaleAparteman> tbl_SaleAparteman { get; set; }
        public virtual ICollection<tbl_SaleMaghaze> tbl_SaleMaghaze { get; set; }
        public virtual ICollection<tbl_SaleVila> tbl_SaleVila { get; set; }
    }
}
