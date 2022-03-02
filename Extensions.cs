using System;

namespace SomeTest
{
    public static class Extensions
    {
        public static string GuidString32 => Guid.NewGuid().ToString().Replace("-", "");
        public static string GuidString16 => Guid.NewGuid().ToString().Replace("-", "").Substring(16);

    }
}
