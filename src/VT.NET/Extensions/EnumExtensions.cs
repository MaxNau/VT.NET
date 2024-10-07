using System;
using System.Text.Json;

namespace VT.NET.Extensions
{
    internal static class EnumExtensions
    {
        internal static string ToString(this Enum value, JsonNamingPolicy jsonNamingPolicy = null)
        {
            return jsonNamingPolicy == null ? value.ToString() : jsonNamingPolicy.ConvertName(value.ToString());
        }
    }
}
