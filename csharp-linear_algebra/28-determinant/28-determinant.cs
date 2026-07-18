using System;

/// <summary>
/// Provides mathematical operations on matrices.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Calculates the determinant of a 2x2 or 3x3 square matrix.
    /// </summary>
    /// <param name="matrix">A square matrix. Only 2x2 and 3x3 dimensions are supported.</param>
    /// <returns>
    /// The determinant of the matrix. Returns <c>-1</c> if the matrix is not 2x2 or 3x3
    /// (including when the input is not square).
    /// </returns>
    public static double Determinant(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != cols)
            return -1;

        if (rows == 2)
        {
            return Math.Round(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0], 2);
        }
        else if (rows == 3)
        {
            return Math.Round(
                matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
              - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
              + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]),
              2);
        }
        else
        {
            return -1;
        }
    }
}
