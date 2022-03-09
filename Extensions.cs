using System;

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

    }
    
}
