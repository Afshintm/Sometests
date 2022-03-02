using FluentAssertions;
using Xunit;

namespace SomeTest
{
    public class PersonTests
    {
        [Fact]
        public void PersonShouldHaveNameLessThan10Long()
        {
            var p = new Person();
            p.Name = "AfshinTeymoori";
            p.Name.Should().NotBe(null);
            p.Name.Length.Should().BeLessOrEqualTo(10);
        }

        [Fact]
        public void PersonShouldHaveNameProperty()
        {
            var p = new Person();
            p.Name = "AfshinTeymoori";
            p.Name.Should().NotBe(null);

        }

        [Fact]
        public void PersonShouldHaveIntroMehod()
        {
            var p = new Person();
            p.Name = "AfshinTeymoori";
            p.Age = 45;
            var Result = p.Introduce();
            Result.Should().NotBeNull();
            Result.Should().Contain(p.Age.ToString(),p.Name);
        }
    }
}

