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
    
    public partial class tbl_EjareMaghaze
    {
        public int intId { get; set; }
        public string chrDate { get; set; }
        public Nullable<bool> blnEslah { get; set; }
        public string chrDateEslah { get; set; }
        public string chrPhone1 { get; set; }
        public string chrPhone2 { get; set; }
        public string chrPhone3 { get; set; }
        public Nullable<int> intIdAddress { get; set; }
        public string chrAddressMelk { get; set; }
        public string chrPelak { get; set; }
        public Nullable<double> fltFloor { get; set; }
        public Nullable<double> fltZirbana { get; set; }
        public Nullable<short> sintTPhone { get; set; }
        public Nullable<bool> blnPark { get; set; }
        public Nullable<double> fltMetrajAnbari { get; set; }
        public Nullable<byte> tintOmr { get; set; }
        public Nullable<bool> blnGaz { get; set; }
        public Nullable<int> intIdNama { get; set; }
        public Nullable<int> intIdKaf { get; set; }
        public Nullable<bool> blnAbdarkhaneh { get; set; }
        public Nullable<double> fltMetrajBalcon { get; set; }
        public Nullable<int> intIdHararat { get; set; }
        public string chrMolahezat { get; set; }
        public Nullable<int> intIdNJavaz { get; set; }
        public Nullable<double> fltBar { get; set; }
        public string chrJob { get; set; }
        public string chrName { get; set; }
        public Nullable<int> intIdNBargh { get; set; }
        public Nullable<bool> blnAb { get; set; }
        public Nullable<bool> blnWC { get; set; }
        public Nullable<double> fltErtefa { get; set; }
        public Nullable<int> intIdJusti { get; set; }
        public Nullable<int> intIdWall { get; set; }
        public Nullable<int> intIdTablo { get; set; }
        public Nullable<bool> blnVitrin { get; set; }
        public Nullable<bool> blnGhafaseh { get; set; }
        public Nullable<double> fltVadieh { get; set; }
        public Nullable<double> fltEjare { get; set; }
        public Nullable<int> number2 { get; set; }
        public Nullable<bool> blnIsPersonal { get; set; }
        public Nullable<int> intIdResidan { get; set; }
        public string chrTavasot { get; set; }
        public string chrVaredkonandeh { get; set; }
    
        public virtual tbl_BaseAddress tbl_BaseAddress { get; set; }
        public virtual tbl_BaseHararat tbl_BaseHararat { get; set; }
        public virtual tbl_BaseJusti tbl_BaseJusti { get; set; }
        public virtual tbl_BaseKaf tbl_BaseKaf { get; set; }
        public virtual tbl_BaseNama tbl_BaseNama { get; set; }
        public virtual tbl_BaseNBargh tbl_BaseNBargh { get; set; }
        public virtual tbl_BaseNJavaz tbl_BaseNJavaz { get; set; }
        public virtual tbl_BaseResidan tbl_BaseResidan { get; set; }
        public virtual tbl_BaseTablo tbl_BaseTablo { get; set; }
        public virtual tbl_BaseWall tbl_BaseWall { get; set; }
    }
}