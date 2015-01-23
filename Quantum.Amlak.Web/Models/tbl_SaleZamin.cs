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
    
    public partial class tbl_SaleZamin
    {
        public int intId { get; set; }
        public string chrDate { get; set; }
        public Nullable<bool> blnEslah { get; set; }
        public string chrDateEslah { get; set; }
        public string chrName { get; set; }
        public string chrPhone1 { get; set; }
        public string chrPhone2 { get; set; }
        public string chrPhone3 { get; set; }
        public Nullable<int> intIdAddress { get; set; }
        public string chrAddressMelk { get; set; }
        public string chrPelak { get; set; }
        public Nullable<int> intIdMahdoodeh { get; set; }
        public Nullable<int> intIdJusti { get; set; }
        public Nullable<int> intIdZRegion { get; set; }
        public Nullable<double> fltTarakom { get; set; }
        public Nullable<double> fltEslahi { get; set; }
        public Nullable<double> fltmetraj { get; set; }
        public Nullable<bool> blnWall { get; set; }
        public Nullable<int> intIdSanad { get; set; }
        public Nullable<double> fltBar { get; set; }
        public Nullable<bool> blnAsfalt { get; set; }
        public Nullable<bool> blnAb { get; set; }
        public Nullable<bool> blnBargh { get; set; }
        public Nullable<double> fltTool { get; set; }
        public Nullable<bool> blnChaheAb { get; set; }
        public Nullable<byte> tintFaseleh { get; set; }
        public Nullable<double> fltPrice { get; set; }
        public Nullable<double> fltMetri { get; set; }
        public string chrMolahezat { get; set; }
        public Nullable<bool> blnBuildCrt { get; set; }
        public Nullable<int> intIdMalekiat { get; set; }
        public string chrNTree { get; set; }
        public Nullable<int> number2 { get; set; }
        public Nullable<bool> blnIsPersonal { get; set; }
        public Nullable<int> intIdResidan { get; set; }
        public string chrTavasot { get; set; }
        public string chrVaredkonandeh { get; set; }
    
        public virtual tbl_BaseAddress tbl_BaseAddress { get; set; }
        public virtual tbl_BaseJusti tbl_BaseJusti { get; set; }
        public virtual tbl_BaseMahdoodeh tbl_BaseMahdoodeh { get; set; }
        public virtual tbl_BaseMalekiat tbl_BaseMalekiat { get; set; }
        public virtual tbl_BaseResidan tbl_BaseResidan { get; set; }
        public virtual tbl_BaseSanad tbl_BaseSanad { get; set; }
        public virtual tbl_BaseZRegion tbl_BaseZRegion { get; set; }
    }
}