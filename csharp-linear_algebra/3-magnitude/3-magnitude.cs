using System;

/// <summary>
/// Provides mathematical operations on 2D and 3D vectors.
/// </summary>
public static class VectorMath
{
    /// <summary>
    /// Calculates the length (magnitude) of a 2D or 3D vector.
    /// </summary>
    /// <param name="vector">An array representing a 2D (length 2) or 3D (length 3) vector.</param>
    /// <returns>
    /// The magnitude of the vector rounded to the nearest hundredth,
    /// or -1 if the vector is not 2D or 3D.
    /// </returns>
    public static double Magnitude(double[] vector)
    {
        if (vector == null || (vector.Length != 2 && vector.Length != 3))
            return -1;

        double sumOfSquares = 0.0;
        foreach (double component in vector)
            sumOfSquares += Math.Pow(component, 2);

        return Math.Round(Math.Sqrt(sumOfSquares), 2);
    }
}
