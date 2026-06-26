using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void IsPalindrome_SimplePalindrome_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome("racecar"));
        }

        [Test]
        public void IsPalindrome_Level_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome("level"));
        }

        [Test]
        public void IsPalindrome_MixedCase_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome("RaceCar"));
        }

        [Test]
        public void IsPalindrome_WithSpacesAndPunctuation_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome("A man, a plan, a canal: Panama."));
        }

        [Test]
        public void IsPalindrome_EmptyString_ReturnsTrue()
        {
            Assert.IsTrue(Str.IsPalindrome(""));
        }

        [Test]
        public void IsPalindrome_NotPalindrome_ReturnsFalse()
        {
            Assert.IsFalse(Str.IsPalindrome("hello"));
        }
    }
}
