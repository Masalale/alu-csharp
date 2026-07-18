/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Multiplies two matrices using standard matrix multiplication.
    /// The number of columns in <paramref name="matrix1"/> must equal the
    /// number of rows in <paramref name="matrix2"/>.
    /// </summary>
    /// <param name="matrix1">The first matrix (m x n).</param>
    /// <param name="matrix2">The second matrix (n x p).</param>
    /// <returns>
    /// A new m x p matrix representing the product, or
    /// <c>new double[,] { { -1 } }</c> if the matrices cannot be multiplied
    /// (i.e. the number of columns in <paramref name="matrix1"/> does not
    /// equal the number of rows in <paramref name="matrix2"/>).
    /// </returns>
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
        {
            return new double[,] { { -1 } };
        }

        double[,] result = new double[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                double sum = 0;
                for (int k = 0; k < cols1; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }
}
