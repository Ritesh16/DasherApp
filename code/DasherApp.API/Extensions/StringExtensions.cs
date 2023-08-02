using System.Globalization;

namespace DasherApp.API.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ParseDate(this string value)
        {
            var date = DateTime.ParseExact(value, "MMddyyyy", CultureInfo.InvariantCulture);
            return date;
        } 
    }
}
