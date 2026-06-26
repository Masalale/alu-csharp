using System;

namespace MyMath
{
    /// <summary>Matrix helpers.</summary>
    public static class Matrix
    {
        /// <summary>Divides every element of a matrix by num.</summary>
        /// <param name="matrix">Matrix to divide.</param>
        /// <param name="num">Divisor.</param>
        /// <returns>New divided matrix, or null if matrix is null or num is 0.</returns>
        public static int[,] Divide(int[,] matrix, int num)
        {
            if (matrix == null)
                return null;

            try
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                int[,] result = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result[i, j] = matrix[i, j] / num;
                    }
                }
                return result;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Num cannot be 0");
                return null;
            }
        }
    }
}
