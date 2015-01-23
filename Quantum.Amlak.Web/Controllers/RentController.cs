using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Quantum.Amlak.Web.Models;

namespace Quantum.Amlak.Web.Controllers
{
    public enum AmlakResponseType
    {
        FileUrl,
        AccountData,
        NotRegistered,
        AccountExpired,
        UpdateNeeded,
    }
    [DataContract(Name = "AmlakResponse")]
    public class AmlakResponse
    {
        [DataMember(Name = "ResponseType")]
        public AmlakResponseType ResponseType { get; set; }
        [DataMember(Name = "ResponseValue")]
        public string ResponseValue { get; set; }
        [DataMember(Name = "AdditionalData")]
        public string[] AdditionalData { get; set; }
    }

    [System.Web.Http.RoutePrefix("api/Rent")]
    public class RentController : ApiController
    {

        public const int MaxFilesInPackage = 30;
        [System.Web.Http.Route("GetFiles")]
        public FileRequestResponse GetFiles(string buildingtype,
            string contracttype,
            string from,
            string to)
        {
            BuildingType buildingType;
            if (!Enum.TryParse(buildingtype, true, out buildingType))
                return null;
            using (var dbc = new AmlakMainEntities())
            {
                switch (buildingType)
                {
                    case BuildingType.Aparteman:
                        if (contracttype != null && contracttype.Contains("ejare"))
                            return new FileRequestResponse { Files = dbc.GetRentApartments(from, to) };
                        if (contracttype != null && contracttype.Contains("forosh"))
                            return new FileRequestResponse { Files = dbc.GetSaleApartments(from, to) };
                        break;
                    case BuildingType.Maghaze:
                        break;
                    case BuildingType.Mostaghelat:
                        break;
                    case BuildingType.Vila:
                        break;
                    case BuildingType.Zamin:
                        break;
                }
            }
            return null;
        }

        public int GetFilesCount(string buildingtype,
            string contracttype, string from, string to)
        {
            BuildingType buildingType;
            if (!Enum.TryParse(buildingtype, true, out buildingType))
                return -1;
            using (var dbc = new AmlakMainEntities())
            {
                switch (buildingType)
                {
                    case BuildingType.Aparteman:
                        return dbc.GetRentApartmentsCount(from, to);
                    case BuildingType.Maghaze:
                        return dbc.GetRentApartmentsCount(from, to);
                    case BuildingType.Mostaghelat:
                        break;
                    case BuildingType.Vila:
                        break;
                    case BuildingType.Zamin:
                        break;
                }
            }
            return -1;
        }

        [System.Web.Http.Route("GetAmlakFile")]
        [System.Web.Http.HttpGet]
        public void GetFile(string fileName)
        {
            var fullFilePath = Path.Combine(Helper.AmlakFilesFolderPath, fileName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.ContentType = "text/csv";
            using (var fileStream = File.OpenRead(fullFilePath))
            {
                const int bufferSize = 1 << 10;
                var buffer = new byte[bufferSize];
                var count = fileStream.Read(buffer, 0, bufferSize);
                while (count > 0)
                {
                    HttpContext.Current.Response.OutputStream.Write(buffer, 0, count);
                    count = fileStream.Read(buffer, 0, bufferSize);
                }
            }
            HttpContext.Current.Response.End();

        }

        [System.Web.Http.Route("Update")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public AmlakResponse UpdateFiles(string deviceId)
        {
            using (var accountingDb = new AmlakAccountingDbEntities())
            {
                if (accountingDb.HasCredit(deviceId))
                {
                    var keyAddress = Helper.CreateAmlakResponse(deviceId);
                    return new AmlakResponse
                    {
                        ResponseType = AmlakResponseType.FileUrl,
                        ResponseValue = keyAddress[0],
                        AdditionalData = new[] { keyAddress[1], keyAddress[2] }
                    };
                }
                if (!accountingDb.AuthenticateDevice(deviceId))
                    //device not registered
                    return new AmlakResponse
                    {
                        ResponseType = AmlakResponseType.NotRegistered,
                        ResponseValue = "دستگاه شما ثبت نشده است"
                    };
                //account expired
                return new AmlakResponse
                {
                    ResponseType = AmlakResponseType.AccountExpired,
                    ResponseValue = "اعتبار شما به پایان رسیده است"
                };
            }
        }

    }
}
