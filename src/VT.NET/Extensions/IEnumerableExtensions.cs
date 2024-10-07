using System.Collections;
using System.Text;
using System.Text.Json;

namespace VT.NET.Extensions
{
    internal static class IEnumerableExtensions
    {
        internal static string ToCommaSeparatedString(this IEnumerable values, JsonNamingPolicy jsonNamingPolicy = null)
        {
            if (values == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            bool first = true;

            foreach (var value in values)
            {
                if (value != null)
                {
                    if (!first)
                    {
                        stringBuilder.Append(",");
                    }
                    if (value != null)
                    {
                        stringBuilder.Append(jsonNamingPolicy != null ? jsonNamingPolicy.ConvertName(value.ToString()) : value.ToString());
                    }
                    first = false;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
