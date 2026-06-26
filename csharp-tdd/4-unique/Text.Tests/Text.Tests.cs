using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void UniqueChar_FirstCharUnique_ReturnsZero()
        {
            Assert.AreEqual(0, Str.UniqueChar("abc"));
        }

        [Test]
        public void UniqueChar_AllUnique_ReturnsFirstIndex()
        {
            Assert.AreEqual(0, Str.UniqueChar("abcdef"));
        }

        [Test]
        public void UniqueChar_AllSame_ReturnsNegativeOne()
        {
            Assert.AreEqual(-1, Str.UniqueChar("aaaa"));
        }

        [Test]
        public void UniqueChar_MiddleUnique_ReturnsCorrectIndex()
        {
            Assert.AreEqual(3, Str.UniqueChar("aabcb"));
        }

        [Test]
        public void UniqueChar_EmptyString_ReturnsNegativeOne()
        {
            Assert.AreEqual(-1, Str.UniqueChar(""));
        }
    }
}
