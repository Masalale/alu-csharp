using System;

/// <summary>
/// Provides mathematical operations on 2D and 3D vectors.
/// </summary>
public static class VectorMath
{
    /// <summary>
    /// Multiplies a 2D or 3D vector by a scalar.
    /// </summary>
    /// <param name="vector">The 2D or 3D vector to scale.</param>
    /// <param name="scalar">The scalar value to multiply each component by.</param>
    /// <returns>
    /// A new array containing the scaled vector,
    /// or a new array containing only -1 if the vector is not 2D or 3D.
    /// </returns>
    public static double[] Multiply(double[] vector, double scalar)
    {
        if (vector == null || (vector.Length != 2 && vector.Length != 3))
            return new double[] { -1 };

        double[] result = new double[vector.Length];
        for (int i = 0; i < vector.Length; i++)
            result[i] = vector[i] * scalar;

        return result;
    }
}
