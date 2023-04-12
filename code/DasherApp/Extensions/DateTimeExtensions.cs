namespace DasherApp.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToDateTimeString(this DateTime dateTime)
        {
            return $"{dateTime.Month.ToValidMonthDay()}{dateTime.Day.ToValidMonthDay()}{dateTime.Year}";
        }

        public static string ToValidMonthDay(this int number)
        {
            var output = string.Empty;
            if (number >= 10)
            {
                output = number.ToString();
            }
            else
            {
                output = $"0{number}";
            }

            return output;
        }
    }
}
