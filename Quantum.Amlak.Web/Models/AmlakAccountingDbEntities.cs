using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PersianDate;

namespace Quantum.Amlak.Web.Models
{
    public partial class AmlakAccountingDbEntities
    {
        public bool AuthenticateDevice(string deviceId)
        {
            return Device.Any(x => x.DeviceId == deviceId);
        }

        public bool HasCredit(string deviceId)
        {
            return AuthenticateDevice(deviceId) &&
                Device.First(x => x.DeviceId == deviceId).
                User.Credit.Any(x => x.StartFrom.AddDays(x.Length).CompareTo(DateTime.Now) > 0);
        }
    }
}