namespace DasherApp.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateTimeString(this DateTime dateTime)
        {
            return $"{dateTime.Month}{dateTime.Day}{dateTime.Year}";
        }
    }
}
