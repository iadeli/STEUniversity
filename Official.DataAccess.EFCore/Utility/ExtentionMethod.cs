using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Official.Persistence.EFCore.Utility
{
    public static class ExtentionMethod
    {
        public static string ToShamsiDateTime(this DateTime dateTime)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                var date = pc.GetYear(dateTime).ToString("0000");
                var month = pc.GetMonth(dateTime).ToString("00");
                var day = pc.GetDayOfMonth(dateTime).ToString("00");
                var time = dateTime.TimeOfDay.ToString("HH:mm:ss");
                var shamsiDate = date + "/" + month + "/" + day + " " + time;
                return shamsiDate;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
