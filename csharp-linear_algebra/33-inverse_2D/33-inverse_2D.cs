using System;

/// <summary>
/// Provides mathematical operations on matrices.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Calculates the inverse of a 2x2 matrix.
    /// </summary>
    /// <param name="matrix">A 2x2 matrix.</param>
    /// <returns>
    /// A new 2x2 matrix that is the inverse of the input, with each element rounded to the
    /// nearest hundredth via <see cref="Math.Round(double, int)"/>. Returns a 1x1 matrix
    /// containing <c>-1</c> if the input is not 2x2 or if the matrix is not invertible
    /// (determinant equals zero).
    /// </returns>
    public static double[,] Inverse2D(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (rows != 2 || cols != 2)
            return new double[,] { { -1 } };

        double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        if (det == 0)
            return new double[,] { { -1 } };

        double a = Math.Round(matrix[1, 1] / det, 2);
        double b = Math.Round(-matrix[0, 1] / det, 2);
        double c = Math.Round(-matrix[1, 0] / det, 2);
        double d = Math.Round(matrix[0, 0] / det, 2);

        return new double[,] { { a, b }, { c, d } };
    }
}
