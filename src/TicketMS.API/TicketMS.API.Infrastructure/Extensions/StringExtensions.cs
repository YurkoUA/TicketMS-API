using System.Linq;

namespace TicketMS.API.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToLower(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            return string.Concat(str.First().ToString().ToLower(), str.Substring(1));
        }
    }
}
