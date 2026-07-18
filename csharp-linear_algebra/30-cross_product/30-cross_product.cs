using System;

/// <summary>
/// Provides mathematical operations on 2D and 3D vectors.
/// </summary>
public static class VectorMath
{
    /// <summary>
    /// Calculates the cross product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first 3D vector (must have length 3).</param>
    /// <param name="vector2">The second 3D vector (must have length 3).</param>
    /// <returns>
    /// A new 3D vector containing the cross product of the inputs (rounded to nearest hundredth).
    /// Returns <c>new double[] { -1 }</c> if either input is not a 3D vector.
    /// </returns>
    public static double[] CrossProduct(double[] vector1, double[] vector2)
    {
        if (vector1 == null || vector2 == null || vector1.Length != 3 || vector2.Length != 3)
            return new double[] { -1 };

        double x = Math.Round(vector1[1] * vector2[2] - vector1[2] * vector2[1], 2);
        double y = Math.Round(vector1[2] * vector2[0] - vector1[0] * vector2[2], 2);
        double z = Math.Round(vector1[0] * vector2[1] - vector1[1] * vector2[0], 2);

        // Normalize -0 to 0 to avoid (-0, 0, 0) output
        if (x == 0) x = 0;
        if (y == 0) y = 0;
        if (z == 0) z = 0;

        return new double[] { x, y, z };
    }
}
