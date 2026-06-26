using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Divide_ValidMatrix_ReturnsDividedMatrix()
        {
            int[,] matrix = { { 10, 20 }, { 30, 40 } };
            int[,] result = Matrix.Divide(matrix, 2);
            Assert.AreEqual(5, result[0, 0]);
            Assert.AreEqual(10, result[0, 1]);
            Assert.AreEqual(15, result[1, 0]);
            Assert.AreEqual(20, result[1, 1]);
        }

        [Test]
        public void Divide_NumIsZero_ReturnsNull()
        {
            int[,] matrix = { { 10, 20 } };
            int[,] result = Matrix.Divide(matrix, 0);
            Assert.IsNull(result);
        }

        [Test]
        public void Divide_NullMatrix_ReturnsNull()
        {
            int[,] result = Matrix.Divide(null, 2);
            Assert.IsNull(result);
        }
    }
}
