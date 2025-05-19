using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotsOfFun.Model;

namespace LotsOfFun.Services.Helper
{
    public static class StringFormatter
    {
        public static string FormatAddress(Address? address)
        {
            if (address is null) return string.Empty;

            var unit = string.IsNullOrWhiteSpace(address.UnitNumber) ? "" : $" bus {address.UnitNumber}";
            return $"{address.Street} {address.Number}{unit}, {address.PostalCode} {address.City}";

        }
    }
}
