using System;

/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Shears a square 2D matrix by a given shear factor along the specified axis.
    /// Applies shear via matrix multiplication on the right (M × shearMatrix).
    /// </summary>
    /// <param name="matrix">A 2×2 matrix.</param>
    /// <param name="direction">Shear axis: 'x' or 'y'.</param>
    /// <param name="factor">The shear factor.</param>
    /// <returns>
    /// A new 2×2 sheared matrix with each element rounded to the nearest hundredth,
    /// or <c>new double[,] { { -1 } }</c> if the matrix is not 2×2 or the direction is invalid.
    /// </returns>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        if (matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2)
            return new double[,] { { -1 } };

        double[,] shearMatrix;
        if (direction == 'x' || direction == 'X')
            shearMatrix = new double[,] { { 1, 0 }, { factor, 1 } };
        else if (direction == 'y' || direction == 'Y')
            shearMatrix = new double[,] { { 1, factor }, { 0, 1 } };
        else
            return new double[,] { { -1 } };

        double[,] result = new double[2, 2];
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                for (int k = 0; k < 2; k++)
                    result[i, j] = Math.Round(result[i, j] + matrix[i, k] * shearMatrix[k, j], 2);

        return result;
    }
}
