using System;

namespace SomeTest
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class PriorityAttribute: Attribute
    {
        public PriorityAttribute(int value) => this.Value = value;

        internal int Value { get; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MyDescriptionAttribute: Attribute
    {
        public MyDescriptionAttribute(string description)
        {
            _value = description;
        }

        private readonly string _value;
        
    }
}
