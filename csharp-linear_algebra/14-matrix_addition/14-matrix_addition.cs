/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Adds two matrices element-wise. Both matrices must be the same size,
    /// and each must be either 2x2 or 3x3.
    /// </summary>
    /// <param name="matrix1">The first matrix (2x2 or 3x3).</param>
    /// <param name="matrix2">The second matrix (2x2 or 3x3).</param>
    /// <returns>
    /// A new matrix containing the element-wise sum, or
    /// <c>new double[,] { { -1 } }</c> if either matrix is not 2x2 or 3x3,
    /// or if the two matrices are not the same size.
    /// </returns>
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
            matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            return new double[,] { { -1 } };
        }

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if ((rows != 2 && rows != 3) || (cols != 2 && cols != 3))
        {
            return new double[,] { { -1 } };
        }

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }
}
