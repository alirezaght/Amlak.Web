using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Quantum.Amlak.Web.Models
{
    [DataContract(Name = "Res")]
    public class FileRequestResponse
    {
        [DataMember(Name = "FA")]
        public IEnumerable<AmlakFile> Files { get; set; }
        [DataMember(Name = "PI")]
        public int PageIndex { get; set; }
        [DataMember(Name = "TP")]
        public int TotalPages { get; set; }
    }

    public enum ContractType
    {
        Ejare,
        Forosh,

    }
    public enum BuildingType
    {
        Aparteman,
        Maghaze,
        Mostaghelat,
        Vila,
        Zamin
    }

    [DataContract(Name = "File")]
    public abstract class AmlakFile
    {
        [DataMember(Name = "CD")]
        public string CreateDate { get; set; }
        [DataMember(Name = "OW")]
        public string OwnerName { get; set; }
        [DataMember(Name = "PH")]
        public IEnumerable<string> PhoneNos { get; set; }
        [DataMember(Name = "AD")]
        public string Address { get; set; }
        [DataMember(Name = "OD")]
        public string OtherDescription { get; set; }
        [DataMember(Name = "FT")]
        public BuildingType BuildingType { get; private set; }
        [DataMember(Name = "AR")]
        public int Area { get; set; }
        [DataMember(Name = "OS")]
        public string OtherSpces { get; set; }
        [DataMember(Name = "MT")]
        public ulong MortgageValue { get; set; }
        [DataMember(Name = "RV")]
        public ulong RentValue { get; set; }
        [DataMember(Name = "MC")]
        public ulong MeterCost { get; set; }
        [DataMember(Name = "TC")]
        public ulong TotalCost { get; set; }
        [DataMember(Name = "CT")]
        public ContractType ContractType { get; set; }
        [DataMember(Name = "TD")]
        public string TransferDate { get; set; }
        protected AmlakFile(BuildingType type)
        {
            BuildingType = type;
        }
    }

    [DataContract(Name = "AP")]
    public class Aparteman : AmlakFile
    {
        public Aparteman()
            : base(BuildingType.Aparteman)
        {
        }
        [DataMember(Name = "FL")]
        public string Floor { get; set; }
        [DataMember(Name = "FS")]
        public string Floors { get; set; }
        [DataMember(Name = "NU")]
        public int NoUnitsPerFloor { get; set; }
        [DataMember(Name = "NR")]
        public int Rooms { get; set; }
        [DataMember(Name = "PL")]
        public bool HasParkingLot { get; set; }
        [DataMember(Name = "CA")]
        public int CellarArea { get; set; }
        [DataMember(Name = "AG")]
        public int Age { get; set; }
    }
    [DataContract(Name = "MG")]
    public class Maghaze : AmlakFile
    {
        public Maghaze()
            : base(BuildingType.Maghaze)
        {
        }
        [DataMember(Name = "FL")]
        public string Floor { get; set; }
        [DataMember(Name = "FS")]
        public int CellarArea { get; set; }
        [DataMember(Name = "AG")]
        public int Age { get; set; }
        [DataMember(Name = "US")]
        public string Use { get; set; }
        [DataMember(Name = "CN")]
        public int CertNo { get; set; }
    }
    [DataContract(Name = "MO")]
    public class Mostaghelat : AmlakFile
    {
        [DataMember(Name = "FL")]
        public string Floor { get; set; }
        [DataMember(Name = "FS")]
        public int CellarArea { get; set; }
        [DataMember(Name = "AG")]
        public int Age { get; set; }
        [DataMember(Name = "US")]
        public string Use { get; set; }
        public Mostaghelat()
            : base(BuildingType.Mostaghelat)
        {
        }
    }
    [DataContract(Name = "MO")]
    public class Vila : AmlakFile
    {

        [DataMember(Name = "AG")]
        public int Age { get; set; }
        public Vila()
            : base(BuildingType.Vila)
        {
        }
    }
    public class Zamin : AmlakFile
    {
        [DataMember(Name = "BR")]
        public uint Bar { get; set; }
        public Zamin()
            : base(BuildingType.Zamin)
        {
        }
    }

    public partial class AmlakMainEntities
    {
        public const int MaxResponseLength = 100;

        #region اجاره آپارتمان
        private IQueryable<tbl_EjareAparteman> GetTblEjareApartemanseQueryable(string fromDate, string toDate)
        {
            return tbl_EjareAparteman.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertRentApartemanToFile(IEnumerable<tbl_EjareAparteman> apartemans)
        {
            return apartemans.Select(x => new Aparteman
             {
                 Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                 Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                 Area = (int)x.fltZirbana,
                 CellarArea = (int)(x.fltMetrajAnbari.HasValue ? x.fltMetrajAnbari : 0),
                 CreateDate = x.chrDate,
                 Floor = x.fltFloor.HasValue ? x.fltFloor.ToString() : "",
                 Floors = x.fltFloors.HasValue ? x.fltFloors.ToString() : "",
                 MortgageValue = (ulong)(x.fltVadieh.HasValue ? x.fltVadieh : 0.0),
                 NoUnitsPerFloor = (int)(x.sintUnits.HasValue ? x.sintUnits : 0),
                 OtherDescription = x.chrMolahezat,
                 OwnerName = x.chrName,
                 HasParkingLot = (bool)(x.blnPark.HasValue ? x.blnPark : false),
                 PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
                 RentValue = (ulong)(x.fltEjare.HasValue ? x.fltEjare : 0f),
                 Rooms = (int)(x.tintRoom.HasValue ? x.tintRoom : 0)
             }).ToList();
        }
        public IEnumerable<AmlakFile> GetRentApartments(string fromDate, string toDate, int skip = 0, int count = MaxResponseLength)
        {
            return ConvertRentApartemanToFile(GetTblEjareApartemanseQueryable(fromDate, toDate).OrderBy(x => x.chrDate)
                .Skip(skip)
                .Take(count));
        }
        public int GetRentApartmentsCount(string fromDate, string toDate)
        {
            return GetTblEjareApartemanseQueryable(fromDate, toDate).Count();
        }
        #endregion

        #region فروش آپارتمان
        private IQueryable<tbl_SaleAparteman> GetTbl_SaleApartemanQueryable(string fromDate, string toDate)
        {
            return tbl_SaleAparteman.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertSaleApartemanToFile(IEnumerable<tbl_SaleAparteman> apartemans)
        {
            return apartemans.Select(x => new Aparteman
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                Area = (int)x.fltZirbana,
                CellarArea = (int)(x.fltMetrajAnbari.HasValue ? x.fltMetrajAnbari : 0),
                CreateDate = x.chrDate,
                Floor = x.fltFloor.HasValue ? x.fltFloor.ToString() : "",
                Floors = x.fltFloors.HasValue ? x.fltFloors.ToString() : "",
                MeterCost = (ulong)(x.fltMetri.HasValue ? x.fltMetri : 0.0),
                NoUnitsPerFloor = (int)(x.sintUnits.HasValue ? x.sintUnits : 0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                HasParkingLot = (bool)(x.blnPark.HasValue ? x.blnPark : false),
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
                TotalCost = (ulong)(x.fltPrice.HasValue ? x.fltPrice : 0f),
                Rooms = (int)(x.tintRoom.HasValue ? x.tintRoom : 0)
            });
        }
        public IEnumerable<AmlakFile> GetSaleApartments(string fromDate, string toDate,  int skip = 0,int count = 100)
        {
            return ConvertSaleApartemanToFile(
                GetTbl_SaleApartemanQueryable(fromDate, toDate).
                        Skip(skip).Take(count));
        }
        public int GetSaleApartmentsCount(string fromDate, string toDate)
        {
            return GetTbl_SaleApartemanQueryable(fromDate, toDate).Count();
        } 
        #endregion

        #region فروش مستقلات
        private IQueryable<tbl_SaleMostaghelat> GetTbl_SaleMostaghelatQueryable(string fromDate, string toDate)
        {
            return tbl_SaleMostaghelat.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertSaleMostaghelatToFile(IEnumerable<tbl_SaleMostaghelat> apartemans)
        {
            return apartemans.Select(x => new Mostaghelat
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                Area = (int)(x.fltGround.HasValue ? x.fltGround : 0),
                CreateDate = x.chrDate,
                Floor = x.fltFloors.HasValue ? x.fltFloors.ToString() : "",
                MeterCost = (ulong)(x.fltMetri.HasValue ? x.fltMetri : 0.0),
                TotalCost = (ulong)(x.fltPrice.HasValue ? x.fltPrice : 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetSaleMostaghelat(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertSaleMostaghelatToFile(
                  GetTbl_SaleMostaghelatQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetSaleMostaghelatCount(string fromDate, string toDate)
        {
            return GetTbl_SaleMostaghelatQueryable(fromDate, toDate).Count();
        } 
        #endregion

        #region اجاره مستقلات
        private IQueryable<tbl_EjareMostaghelat> GetTbl_RentMostaghelatQueryable(string fromDate, string toDate)
        {
            return tbl_EjareMostaghelat.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertRentMostaghelatToFile(IEnumerable<tbl_EjareMostaghelat> apartemans)
        {
            return apartemans.Select(x => new Mostaghelat
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                Area = (int)(x.fltGround.HasValue ? x.fltGround : 0),
                CreateDate = x.chrDate,
                Floor = x.fltFloors.HasValue ? x.fltFloors.ToString() : "",
                MortgageValue = (ulong)(x.fltVadieh.HasValue ? x.fltVadieh: 0.0),
                RentValue= (ulong)(x.fltEjare.HasValue ? x.fltEjare: 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetRentMostaghelat(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertRentMostaghelatToFile(
                  GetTbl_RentMostaghelatQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetRentMostaghelatCount(string fromDate, string toDate)
        {
            return GetTbl_RentMostaghelatQueryable(fromDate, toDate).Count();
        }
        #endregion

        #region فروش ویلا
        private IQueryable<tbl_SaleVila> GetTbl_SaleVilaQueryable(string fromDate, string toDate)
        {
            return tbl_SaleVila.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertSaleMostaghelatToFile(IEnumerable<tbl_SaleVila> vilas)
        {
            return vilas.Select(x => new Vila
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                Area = (int)(x.fltGround.HasValue ? x.fltGround : 0),
                CreateDate = x.chrDate,
                MeterCost = (ulong)(x.fltMetri.HasValue ? x.fltMetri : 0.0),
                TotalCost = (ulong)(x.fltPrice.HasValue ? x.fltPrice : 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetSaleVila(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertSaleMostaghelatToFile(
                  GetTbl_SaleVilaQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetSaleVilaCount(string fromDate, string toDate)
        {
            return GetTbl_SaleVilaQueryable(fromDate, toDate).Count();
        }
        #endregion

        #region اجاره ویلا
        private IQueryable<tbl_EjareVila> GetTbl_RentVilaQueryable(string fromDate, string toDate)
        {
            return tbl_EjareVila.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertRentVilaToFile(IEnumerable<tbl_EjareVila> vilas)
        {
            return vilas.Select(x => new Mostaghelat
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                Area = (int)(x.fltGround.HasValue ? x.fltGround : 0),
                CreateDate = x.chrDate,
                MortgageValue = (ulong)(x.fltVadieh.HasValue ? x.fltVadieh : 0.0),
                RentValue = (ulong)(x.fltEjare.HasValue ? x.fltEjare : 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetRentVila(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertRentVilaToFile(
                  GetTbl_RentVilaQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetRentVilaCount(string fromDate, string toDate)
        {
            return GetTbl_RentVilaQueryable(fromDate, toDate).Count();
        }
        #endregion

        #region فروش مغازه
        private IQueryable<tbl_SaleMaghaze> GetTbl_SaleMaghazeQueryable(string fromDate, string toDate)
        {
            return tbl_SaleMaghaze.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertSaleMaghazeToFile(IEnumerable<tbl_SaleMaghaze> apartemans)
        {
            return apartemans.Select(x => new Maghaze
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                CreateDate = x.chrDate,
                MeterCost = (ulong)(x.fltMMetri.HasValue ? x.fltMMetri: 0.0),
                TotalCost = (ulong)(x.fltRuyeham.HasValue ? x.fltRuyeham: 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetSaleMaghaze(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertSaleMaghazeToFile(
                  GetTbl_SaleMaghazeQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetSaleMaghazeCount(string fromDate, string toDate)
        {
            return GetTbl_SaleMaghazeQueryable(fromDate, toDate).Count();
        }
        #endregion

        #region اجاره مغازه
        private IQueryable<tbl_EjareMaghaze> GetTbl_RentMaghazeQueryable(string fromDate, string toDate)
        {
            return tbl_EjareMaghaze.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertRentMaghazeToFile(IEnumerable<tbl_EjareMaghaze> apartemans)
        {
            return apartemans.Select(x => new Maghaze
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Age = (int)(x.tintOmr.HasValue ? x.tintOmr : 0),
                Area = (int)(x.fltZirbana.HasValue ? x.fltZirbana: 0),
                CreateDate = x.chrDate,
                Floor = x.fltFloor.HasValue ? x.fltFloor.ToString() : "",
                MortgageValue = (ulong)(x.fltVadieh.HasValue ? x.fltVadieh : 0.0),
                RentValue = (ulong)(x.fltEjare.HasValue ? x.fltEjare : 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetRentMaghaze(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertRentMaghazeToFile(
                  GetTbl_RentMaghazeQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetRentMaghazeCount(string fromDate, string toDate)
        {
            return GetTbl_RentMaghazeQueryable(fromDate, toDate).Count();
        }
        #endregion

        #region فروش زمین
        private IQueryable<tbl_SaleZamin> GetTbl_SaleZaminQueryable(string fromDate, string toDate)
        {
            return tbl_SaleZamin.Where(x => String.Compare(x.chrDate, fromDate, StringComparison.Ordinal) > 0 &&
                                                 String.Compare(x.chrDate, toDate, StringComparison.Ordinal) < 0).
                OrderBy(x => x.chrDate);
        }
        private IEnumerable<AmlakFile> ConvertSaleZaminToFile(IEnumerable<tbl_SaleZamin> apartemans)
        {
            return apartemans.Select(x => new Zamin
            {
                Address = x.chrAddressMelk + " پلاک " + x.chrPelak,
                Area = (int)(x.fltmetraj.HasValue ? x.fltmetraj: 0),
                CreateDate = x.chrDate,
                MeterCost = (ulong)(x.fltMetri.HasValue ? x.fltMetri : 0.0),
                TotalCost = (ulong)(x.fltPrice.HasValue ? x.fltPrice : 0.0),
                OtherDescription = x.chrMolahezat,
                OwnerName = x.chrName,
                PhoneNos = new[] { x.chrPhone1, x.chrPhone2, x.chrPhone3 },
            }).ToList();
        }
        public IEnumerable<AmlakFile> GetSaleZamin(string fromDate, string toDate, int skip = 0, int count = 100)
        {
            return ConvertSaleZaminToFile(
                  GetTbl_SaleZaminQueryable(fromDate, toDate).
                          Skip(skip).Take(count));
        }
        public int GetSaleZaminCount(string fromDate, string toDate)
        {
            return GetTbl_SaleZaminQueryable(fromDate, toDate).Count();
        }
        #endregion

    }
}