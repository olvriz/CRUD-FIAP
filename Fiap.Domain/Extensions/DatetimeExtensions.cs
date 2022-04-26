using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Domain.Extensions
{
    public static class DatetimeExtensions
    {
        public static DateTime ChangeTime(this DateTime dateTime, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hour,
                minute,
                second,
                millisecond,
                dateTime.Kind);
        }

        public static DateTime ToInitialTime(this DateTime dateTime)
        {
            return dateTime.ChangeTime(00, 00, 00, 00);
        }

        public static DateTime ToFinalTime(this DateTime dateTime)
        {
            return dateTime.ChangeTime(23, 59, 59, 59);
        }

        public static bool IsValidSchedulingTime(this DateTime schedulingTime)
        {
            return schedulingTime.ToInitialTime() >= DateTime.Now.ToInitialTime();
        }
    }
}
