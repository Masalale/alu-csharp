using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void CamelCase_SingleWord_ReturnsOne()
        {
            Assert.AreEqual(1, Str.CamelCase("hello"));
        }

        [Test]
        public void CamelCase_TwoWords_ReturnsTwo()
        {
            Assert.AreEqual(2, Str.CamelCase("helloWorld"));
        }

        [Test]
        public void CamelCase_MultipleWords_ReturnsCount()
        {
            Assert.AreEqual(6, Str.CamelCase("thisIsACamelCaseString"));
        }

        [Test]
        public void CamelCase_EmptyString_ReturnsZero()
        {
            Assert.AreEqual(0, Str.CamelCase(""));
        }
    }
}
