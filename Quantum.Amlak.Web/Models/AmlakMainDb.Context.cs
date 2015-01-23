﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AmlakMainEntities : DbContext
    {
        public AmlakMainEntities()
            : base("name=AmlakMainEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_BaseAddress> tbl_BaseAddress { get; set; }
        public virtual DbSet<tbl_BaseDublex> tbl_BaseDublex { get; set; }
        public virtual DbSet<tbl_BaseHararat> tbl_BaseHararat { get; set; }
        public virtual DbSet<tbl_BaseJusti> tbl_BaseJusti { get; set; }
        public virtual DbSet<tbl_BaseKabinet> tbl_BaseKabinet { get; set; }
        public virtual DbSet<tbl_BaseKaf> tbl_BaseKaf { get; set; }
        public virtual DbSet<tbl_BaseKarbari> tbl_BaseKarbari { get; set; }
        public virtual DbSet<tbl_BaseKitchen> tbl_BaseKitchen { get; set; }
        public virtual DbSet<tbl_BaseMahdoodeh> tbl_BaseMahdoodeh { get; set; }
        public virtual DbSet<tbl_BaseMalekiat> tbl_BaseMalekiat { get; set; }
        public virtual DbSet<tbl_BaseMCategory> tbl_BaseMCategory { get; set; }
        public virtual DbSet<tbl_BaseMobleh> tbl_BaseMobleh { get; set; }
        public virtual DbSet<tbl_BaseNama> tbl_BaseNama { get; set; }
        public virtual DbSet<tbl_BaseNBargh> tbl_BaseNBargh { get; set; }
        public virtual DbSet<tbl_BaseNJavaz> tbl_BaseNJavaz { get; set; }
        public virtual DbSet<tbl_BaseOperator> tbl_BaseOperator { get; set; }
        public virtual DbSet<tbl_BasePool> tbl_BasePool { get; set; }
        public virtual DbSet<tbl_BaseRefer> tbl_BaseRefer { get; set; }
        public virtual DbSet<tbl_BaseResidan> tbl_BaseResidan { get; set; }
        public virtual DbSet<tbl_BaseSanad> tbl_BaseSanad { get; set; }
        public virtual DbSet<tbl_BaseService> tbl_BaseService { get; set; }
        public virtual DbSet<tbl_BaseTablo> tbl_BaseTablo { get; set; }
        public virtual DbSet<tbl_BaseWall> tbl_BaseWall { get; set; }
        public virtual DbSet<tbl_BaseZRegion> tbl_BaseZRegion { get; set; }
        public virtual DbSet<tbl_EjareAparteman> tbl_EjareAparteman { get; set; }
        public virtual DbSet<tbl_EjareMaghaze> tbl_EjareMaghaze { get; set; }
        public virtual DbSet<tbl_EjareMostaghelat> tbl_EjareMostaghelat { get; set; }
        public virtual DbSet<tbl_EjareVila> tbl_EjareVila { get; set; }
        public virtual DbSet<tbl_SaleAparteman> tbl_SaleAparteman { get; set; }
        public virtual DbSet<tbl_SaleMaghaze> tbl_SaleMaghaze { get; set; }
        public virtual DbSet<tbl_SaleMostaghelat> tbl_SaleMostaghelat { get; set; }
        public virtual DbSet<tbl_SaleVila> tbl_SaleVila { get; set; }
        public virtual DbSet<tbl_SaleZamin> tbl_SaleZamin { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<vila> vila { get; set; }
        public virtual DbSet<zamin> zamin { get; set; }
        public virtual DbSet<tbl_BaseFile> tbl_BaseFile { get; set; }
        public virtual DbSet<tbl_BaseResult> tbl_BaseResult { get; set; }
        public virtual DbSet<tbl_DetailEjareMostaghelat> tbl_DetailEjareMostaghelat { get; set; }
        public virtual DbSet<tbl_DetailSaleMostaghelat> tbl_DetailSaleMostaghelat { get; set; }
    
        public virtual ObjectResult<aa_SP_Ap_Rent_Result> aa_SP_Ap_Rent(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Ap_Rent_Result>("aa_SP_Ap_Rent", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Ap_Sale_Result> aa_SP_Ap_Sale(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Ap_Sale_Result>("aa_SP_Ap_Sale", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Shop_Rent_Result> aa_SP_Shop_Rent(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Shop_Rent_Result>("aa_SP_Shop_Rent", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Shop_Sale_Result> aa_SP_Shop_Sale(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Shop_Sale_Result>("aa_SP_Shop_Sale", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Ten_Rent_Result> aa_SP_Ten_Rent(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Ten_Rent_Result>("aa_SP_Ten_Rent", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Ten_Rent_D_Result> aa_SP_Ten_Rent_D(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Ten_Rent_D_Result>("aa_SP_Ten_Rent_D", idParameter);
        }
    
        public virtual ObjectResult<aa_SP_Ten_Sale_Result> aa_SP_Ten_Sale(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Ten_Sale_Result>("aa_SP_Ten_Sale", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Ten_Sale_D_Result> aa_SP_Ten_Sale_D(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Ten_Sale_D_Result>("aa_SP_Ten_Sale_D", idParameter);
        }
    
        public virtual ObjectResult<aa_SP_Villa_Rent_Result> aa_SP_Villa_Rent(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Villa_Rent_Result>("aa_SP_Villa_Rent", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Villa_Sale_Result> aa_SP_Villa_Sale(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Villa_Sale_Result>("aa_SP_Villa_Sale", dtFromParameter, dtToParameter);
        }
    
        public virtual ObjectResult<aa_SP_Zamin_Sale_Result> aa_SP_Zamin_Sale(string dtFrom, string dtTo)
        {
            var dtFromParameter = dtFrom != null ?
                new ObjectParameter("dtFrom", dtFrom) :
                new ObjectParameter("dtFrom", typeof(string));
    
            var dtToParameter = dtTo != null ?
                new ObjectParameter("dtTo", dtTo) :
                new ObjectParameter("dtTo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aa_SP_Zamin_Sale_Result>("aa_SP_Zamin_Sale", dtFromParameter, dtToParameter);
        }
    }
}