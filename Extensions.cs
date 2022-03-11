using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SomeTest
{
    public static class Extensions
    {
        public static string GuidString32 => Guid.NewGuid().ToString().Replace("-", "");
        public static string GuidString16 => Guid.NewGuid().ToString().Replace("-", "").Substring(16);

        public static T? GetPropertyValue<T>(this object obj, string propName)
        {
            if (obj == null)
                return default(T);
            var type = obj.GetType();
            var propertyInfo = type.GetProperty(propName);
            if (propertyInfo == null) throw new Exception("PropertyNotFoundException");
            var result = propertyInfo?.GetValue(obj, null);
            return (T)result!;
        }
        public static JsonSerializerOptions DefaultSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
            Converters = { new JsonStringEnumConverter(allowIntegerValues: false) }
        };
        public static string ToJson<T>(this T objectToSerialize)
        {
            return JsonSerializer.Serialize(objectToSerialize, DefaultSerializerOptions);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultSerializerOptions)!;
        }
    }
    
}
