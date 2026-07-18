/// <summary>
/// Provides static methods for common vector math operations.
/// </summary>
public static class VectorMath
{
    /// <summary>
    /// Calculates the dot product of two vectors. Vectors must be the same size,
    /// and each must be either 2D or 3D.
    /// </summary>
    /// <param name="vector1">The first vector (2D or 3D).</param>
    /// <param name="vector2">The second vector (2D or 3D).</param>
    /// <returns>
    /// The dot product of the two vectors, or <c>-1</c> if either vector is
    /// not 2D or 3D, or if the two vectors are not the same size.
    /// </returns>
    public static double DotProduct(double[] vector1, double[] vector2)
    {
        if (vector1.Length != vector2.Length)
        {
            return -1;
        }

        if (vector1.Length != 2 && vector1.Length != 3)
        {
            return -1;
        }

        double result = 0;
        for (int i = 0; i < vector1.Length; i++)
        {
            result += vector1[i] * vector2[i];
        }

        return result;
    }
}
