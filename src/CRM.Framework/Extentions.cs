using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Framework
{
    public static class Extentions
    {
        public static string ToDateText(this DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return datetime.Value.ToString("MM/dd/yyyy");
            }
            else
            {
                return "-";
            }
        }

        public static string ToInvoiceNo(this int id)
        {
            return $"INV{id:D5}";
        }
    }
}
