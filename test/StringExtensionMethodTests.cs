using System;
using NUnit.Framework;
using src;

namespace test
{
    [TestFixture]
    public class StringExtensionMethodTests
    {
        [Test]
        public void RemoveLineBreaks_Test()
        {
            const string withLineBreak = @"up up down down left right left right
                                           b a select start";
            string withoutLineBreak = withLineBreak.RemoveLineBreaks();
            Assert.That(withoutLineBreak.Contains(Environment.NewLine), Is.False);
        }
        [Test]
        public void RemoveTrailingComma_Test()
        {
            const string before = "ted, fred, ed,";
            const string expected = "ted, fred, ed";
            string result = before.RemoveTrailingComma();
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void ReplaceWordChars_Test()
        {
            const string fromWord = "“hello” –";
            const string expected = "\"hello\" -";

            Assert.That(fromWord.ReplaceWordChars(), Is.EqualTo(expected));
        }
    }
}