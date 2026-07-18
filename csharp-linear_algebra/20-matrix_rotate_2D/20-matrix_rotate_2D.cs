using System;

/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Rotates a square 2D matrix by a given angle in radians.
    /// Applies rotation via matrix multiplication on the right (M × rotationMatrix).
    /// </summary>
    /// <param name="matrix">A 2×2 matrix.</param>
    /// <param name="angle">The rotation angle in radians.</param>
    /// <returns>
    /// A new 2×2 matrix with each element rounded to the nearest hundredth,
    /// or <c>new double[,] { { -1 } }</c> if the matrix does not have exactly 2 columns.
    /// </returns>
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        if (matrix.GetLength(1) != 2)
            return new double[,] { { -1 } };

        double[,] rotationMatrix = {
            { Math.Cos(angle), Math.Sin(angle) },
            { -Math.Sin(angle), Math.Cos(angle) }
        };
        double[,] result = new double[2, 2];

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                for (int k = 0; k < 2; k++)
                    result[i, j] = Math.Round(result[i, j] + matrix[i, k] * rotationMatrix[k, j], 2);

        return result;
    }
}
