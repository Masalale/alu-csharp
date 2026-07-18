/// <summary>
/// Provides static methods for common matrix math operations.
/// </summary>
public static class MatrixMath
{
    /// <summary>
    /// Shears a 2D matrix along the specified axis. Each row is treated as
    /// a point (x, y).
    /// <list type="bullet">
    /// <item>
    /// <description>X shear: <c>newX = x + factor * y</c>, <c>newY = y</c></description>
    /// </item>
    /// <item>
    /// <description>Y shear: <c>newX = x</c>, <c>newY = y + factor * x</c></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="matrix">A 2D matrix where each row is a 2D point (x, y).</param>
    /// <param name="direction">The shear axis: <c>'x'</c> or <c>'y'</c> (case-insensitive).</param>
    /// <param name="factor">The shear factor.</param>
    /// <returns>
    /// A new matrix of the same shape with each row sheared, or
    /// <c>new double[,] { { -1 } }</c> if the matrix does not have exactly
    /// 2 columns, or if <paramref name="direction"/> is not <c>'x'</c> or <c>'y'</c>.
    /// </returns>
    public static double[,] Shear2D(double[,] matrix, char direction, double factor)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (cols != 2)
        {
            return new double[,] { { -1 } };
        }

        char d = char.ToLower(direction);

        if (d != 'x' && d != 'y')
        {
            return new double[,] { { -1 } };
        }

        double[,] result = new double[rows, 2];

        for (int i = 0; i < rows; i++)
        {
            double x = matrix[i, 0];
            double y = matrix[i, 1];

            if (d == 'x')
            {
                result[i, 0] = x + factor * y;
                result[i, 1] = y;
            }
            else
            {
                result[i, 0] = x;
                result[i, 1] = y + factor * x;
            }
        }

        return result;
    }
}
