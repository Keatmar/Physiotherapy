using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physiotherapy.Common
{
    public static class DateTimeUtil
    {
        /// <summary>
        /// Convert time to utc time
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ConvertToUTC(DateTime value)
        {
            TimeSpan time = TimeZone.CurrentTimeZone.GetUtcOffset(value);
            value = value.Date + time;
            return value;
        }

        /// <summary>
        /// Convert time from utc time
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ConvertFromUTC(DateTime value)
        {
            value = TimeZone.CurrentTimeZone.ToLocalTime(value);
            return value;
        }

        /// <summary>
        /// Get date to this format dd/mm/yyyy
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShortDate(DateTime value)
        {
            string date = value.ToShortDateString();
            return date;
        }
    }
}
