using System;

/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Rotates a 2D matrix by applying a 2D rotation transformation to each
    /// row interpreted as a point (x, y).
    /// For a row [x, y] and angle &theta; (in radians):
    /// <c>newX = x * cos(&theta;) - y * sin(&theta;)</c>,
    /// <c>newY = x * sin(&theta;) + y * cos(&theta;)</c>.
    /// </summary>
    /// <param name="matrix">A 2D matrix where each row is a 2D point (x, y).</param>
    /// <param name="angle">The rotation angle in radians.</param>
    /// <returns>
    /// A new matrix of the same shape with each row rotated, or
    /// <c>new double[,] { { -1 } }</c> if the matrix does not have
    /// exactly 2 columns.
    /// </returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (cols != 2)
        {
            return new double[,] { { -1 } };
        }

        double cos = Math.Cos(angle);
        double sin = Math.Sin(angle);

        double[,] result = new double[rows, 2];

        for (int i = 0; i < rows; i++)
        {
            double x = matrix[i, 0];
            double y = matrix[i, 1];
            result[i, 0] = x * cos - y * sin;
            result[i, 1] = x * sin + y * cos;
        }

        return result;
    }
}
