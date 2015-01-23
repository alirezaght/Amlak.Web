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
    
    [Serializable]
    public partial class tbl_EjareAparteman
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
        public Nullable<double> fltFloor { get; set; }
        public Nullable<bool> blnSuit { get; set; }
        public Nullable<double> fltFloors { get; set; }
        public Nullable<byte> tintUnit { get; set; }
        public Nullable<short> sintUnits { get; set; }
        public double fltZirbana { get; set; }
        public Nullable<byte> tintRoom { get; set; }
        public Nullable<short> sintTPhone { get; set; }
        public Nullable<bool> blnPark { get; set; }
        public Nullable<double> fltMetrajAnbari { get; set; }
        public Nullable<byte> tintOmr { get; set; }
        public Nullable<bool> blnAsansor { get; set; }
        public Nullable<bool> blnGaz { get; set; }
        public Nullable<int> intIdDublex { get; set; }
        public Nullable<int> intIdNama { get; set; }
        public Nullable<int> intIdKaf { get; set; }
        public Nullable<int> intIdService { get; set; }
        public Nullable<int> intIdKitchen { get; set; }
        public Nullable<int> intIdKabinet { get; set; }
        public Nullable<double> fltMetrajBalcon { get; set; }
        public Nullable<int> intIdHararat { get; set; }
        public Nullable<bool> blnShomineh { get; set; }
        public Nullable<bool> blnSona { get; set; }
        public Nullable<bool> blnHayat { get; set; }
        public Nullable<int> intIdPool { get; set; }
        public Nullable<bool> blnJakuzi { get; set; }
        public Nullable<double> fltVadieh { get; set; }
        public Nullable<double> fltEjare { get; set; }
        public Nullable<bool> blnDoller { get; set; }
        public Nullable<bool> blnKhareji { get; set; }
        public Nullable<int> intIdKarbari { get; set; }
        public Nullable<bool> blnMalek { get; set; }
        public string chrMolahezat { get; set; }
        public Nullable<int> intIdJusti { get; set; }
        public Nullable<bool> blnIfon { get; set; }
        public Nullable<bool> blnRemoteDoor { get; set; }
        public Nullable<bool> blnSecurity { get; set; }
        public Nullable<int> intIdMobleh { get; set; }
        public Nullable<bool> blnPantHouse { get; set; }
        public Nullable<int> number2 { get; set; }
        public Nullable<bool> blnIsPersonal { get; set; }
        public Nullable<int> intIdResidan { get; set; }
        public string chrTavasot { get; set; }
        public string chrVaredkonandeh { get; set; }
    
        public virtual tbl_BaseAddress tbl_BaseAddress { get; set; }
        public virtual tbl_BaseDublex tbl_BaseDublex { get; set; }
        public virtual tbl_BaseHararat tbl_BaseHararat { get; set; }
        public virtual tbl_BaseJusti tbl_BaseJusti { get; set; }
        public virtual tbl_BaseKabinet tbl_BaseKabinet { get; set; }
        public virtual tbl_BaseKaf tbl_BaseKaf { get; set; }
        public virtual tbl_BaseKarbari tbl_BaseKarbari { get; set; }
        public virtual tbl_BaseKitchen tbl_BaseKitchen { get; set; }
        public virtual tbl_BaseMobleh tbl_BaseMobleh { get; set; }
        public virtual tbl_BaseNama tbl_BaseNama { get; set; }
        public virtual tbl_BasePool tbl_BasePool { get; set; }
        public virtual tbl_BaseResidan tbl_BaseResidan { get; set; }
        public virtual tbl_BaseService tbl_BaseService { get; set; }
    }
}
