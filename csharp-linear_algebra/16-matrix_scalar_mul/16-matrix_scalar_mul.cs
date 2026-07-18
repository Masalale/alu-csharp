/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Multiplies a matrix by a scalar. The matrix must be either 2x2 or 3x3.
    /// </summary>
    /// <param name="matrix">The matrix to scale (2x2 or 3x3).</param>
    /// <param name="scalar">The scalar value to multiply each element by.</param>
    /// <returns>
    /// A new matrix with each element multiplied by <paramref name="scalar"/>,
    /// or <c>new double[,] { { -1 } }</c> if the matrix is not 2x2 or 3x3.
    /// </returns>
    public static double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if ((rows != 2 && rows != 3) || (cols != 2 && cols != 3))
        {
            return new double[,] { { -1 } };
        }

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }

        return result;
    }
}
