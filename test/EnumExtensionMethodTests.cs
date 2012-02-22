using NUnit.Framework;
using src;

namespace test
{
    [TestFixture]
    public class ExtensionMethodTests
    {
        [Test]
        public void Enum_Description_Test()
        {
            Assert.That(TestEnums.Hello.Description(), Is.EqualTo("HELLO"));
        }

        [Test]
        public void Integer_To_Enum_Test()
        {
            const int i = 1;
            Assert.That(i.ToEnum<TestEnums>(), Is.EqualTo(TestEnums.Goodbye));
        }

        private enum TestEnums
        {
            [System.ComponentModel.Description("HELLO")]
            Hello,

            [System.ComponentModel.Description("GOODBYE")]
            Goodbye
        }
    }


}