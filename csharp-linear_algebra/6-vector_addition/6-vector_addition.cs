using System;

/// <summary>
/// Provides mathematical operations on 2D and 3D vectors.
/// </summary>
public static class VectorMath
{
    /// <summary>
    /// Adds two 2D or 3D vectors element-wise.
    /// </summary>
    /// <param name="vector1">The first 2D or 3D vector.</param>
    /// <param name="vector2">The second 2D or 3D vector.</param>
    /// <returns>
    /// A new array containing the element-wise sum of the two vectors,
    /// or a new array containing only -1 if either vector is not 2D or 3D,
    /// or if the two vectors do not have the same size.
    /// </returns>
    public static double[] Add(double[] vector1, double[] vector2)
    {
        if (vector1 == null || vector2 == null)
            return new double[] { -1 };

        if ((vector1.Length != 2 && vector1.Length != 3) ||
            (vector2.Length != 2 && vector2.Length != 3) ||
            vector1.Length != vector2.Length)
            return new double[] { -1 };

        double[] result = new double[vector1.Length];
        for (int i = 0; i < vector1.Length; i++)
            result[i] = vector1[i] + vector2[i];

        return result;
    }
}
