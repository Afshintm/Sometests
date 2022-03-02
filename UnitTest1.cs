using System;
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

    public class UnitTest1
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

    }
}
