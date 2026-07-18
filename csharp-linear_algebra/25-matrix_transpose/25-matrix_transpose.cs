using System;

/// <summary>
/// Provides mathematical operations on matrices.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Transposes a matrix by swapping its rows and columns.
    /// </summary>
    /// <param name="matrix">The matrix to transpose. May be of any dimension.</param>
    /// <returns>
    /// A new matrix that is the transpose of the input, where <c>result[j, i] = matrix[i, j]</c>.
    /// Returns an empty <c>double[0, 0]</c> matrix if the input has zero rows or zero columns.
    /// </returns>
    public static double[,] Transpose(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows == 0 || cols == 0)
            return new double[0, 0];

        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = matrix[i, j];
            }
        }

        return result;
    }
}
