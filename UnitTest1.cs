using System;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace SomeTest
{
    public class Dummy2 { }
    public class DummyClass
    {
        public MigrationEvent? MigrationEvent { get; set; }
        public Dummy2? Dummy2 { get; set; }
    }

    public class SomeTests
    {
        [Fact]
        public void GenerateGuidUniqueStringTest()
        {
            var guidString = Guid.NewGuid().ToString().Replace("-", "");
            var half = guidString.Substring(16);

            guidString.Should().NotBe(null);
            half.Length.Should().Be(16);

        }

        [Fact]
        public void EnumTests()
        {
            //MigrationEvent r;
            var b = Enum.TryParse("Create", true, out MigrationEvent r);
            b.Should().BeTrue();
            r.Should().Be(MigrationEvent.Create);
        }
        [Fact]
        public void NullableEnumTests()
        {
            var dummyClass = new DummyClass();

            var d2 = dummyClass.Dummy2?.ToString();

            var b = dummyClass.MigrationEvent;
            b.Should().BeNull();
            var a = dummyClass.MigrationEvent.ToString();
            a.Should().NotBe(null);
            a.Should().Be(String.Empty);
            var c = dummyClass.MigrationEvent?.ToString();
            var d = dummyClass.MigrationEvent!.ToString();
        }

        [Fact]
        public void ReflectionPropertyValueTest()
        {
            var p = new Person() {Name = "Afshin"};
            var value = p.GetPropertyValue<string>("Name");
            value.Should().Be("Afshin");
        }

        [Fact]
        public void ReflectionAttributeValueTest()
        {
            BindingFlags bindFlags = BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var p = new Person() { Name = "Afshin" };
            var theType = typeof(Person);
            var attributes = System.Attribute.GetCustomAttributes(theType);
            
            foreach (var attr in attributes)
            {
                if (attr is PriorityAttribute)
                {
                    var b = (PriorityAttribute) attr;
                    var propertyInfo = typeof(PriorityAttribute).GetProperty("Value", bindFlags);
                    var val = propertyInfo?.GetValue(b);
                    val.Should().Be(10);
                }

                if (attr is MyDescriptionAttribute)
                {
                    var myDescriptionAttribute = (MyDescriptionAttribute)attr;
                    var filedInfo =  typeof(MyDescriptionAttribute).GetField("_value",bindFlags);
                    var val = filedInfo?.GetValue(myDescriptionAttribute);
                    val.Should().Be("Hello");
                }
            }

            p.Name.Should().Be("Afshin");
        }

    }
}
