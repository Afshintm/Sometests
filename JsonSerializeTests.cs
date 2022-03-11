using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace SomeTest
{
    public class PaymentCreatedSource
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dummy2 Dummy2 { get; set; }

    }

    public class PaymentCreatedTarget
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dummy2 Dummy2 { get; set; }
        public string PaidAccount { get; set; }

    }

    public class PaymentCreatedOut
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dummy2 Dummy2 { get; set; }
        public string PaidAccount { get; set; }

    }

    public class JsonSerializeTests
    {
        [Fact]
        public void DeserializeClassWithMissingProperty_NewtonJson_Test()
        {
            var source = new PaymentCreatedSource() {Name = "Afshin", Age = 47, Dummy2 = new Dummy2()};
            var jsonConvertserialized = JsonConvert.SerializeObject(source);
            var jsonConvertdeserialized = JsonConvert.DeserializeObject<PaymentCreatedTarget>(jsonConvertserialized);

            jsonConvertdeserialized.PaidAccount.Should().Be(null);
        }

        [Fact]
        public void DeserializeClassWithMissingProperty_JsonText_Test()
        {
            var source = new PaymentCreatedSource() { Name = "Afshin", Age = 47, Dummy2 = new Dummy2() };
            var jsonSerializerSerialized = source.ToJson();
            var jsonSerializerDeserialized = jsonSerializerSerialized.FromJson<PaymentCreatedTarget>();

            jsonSerializerDeserialized.PaidAccount.Should().Be(null);
            var o = new PaymentCreatedOut()
                {Name = jsonSerializerDeserialized.Name, PaidAccount = jsonSerializerDeserialized.PaidAccount};
            o.PaidAccount.Should().Be(null);
        }

    }
}
