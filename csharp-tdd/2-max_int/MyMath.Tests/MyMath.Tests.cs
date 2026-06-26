using System.Collections.Generic;
using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Max_MultipleElements_ReturnsLargest()
        {
            Assert.AreEqual(10, Operations.Max(new List<int> { 1, 5, 10, 3 }));
        }

        [Test]
        public void Max_EmptyList_ReturnsZero()
        {
            Assert.AreEqual(0, Operations.Max(new List<int>()));
        }

        [Test]
        public void Max_NegativeNumbers_ReturnsLargest()
        {
            Assert.AreEqual(-1, Operations.Max(new List<int> { -5, -1, -10 }));
        }

        [Test]
        public void Max_SingleElement_ReturnsElement()
        {
            Assert.AreEqual(42, Operations.Max(new List<int> { 42 }));
        }
    }
}
