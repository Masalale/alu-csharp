using System;

/// <summary>
/// Provides methods for object type and instance checking.
/// </summary>
class Obj
{
    /// <summary>
    /// Returns True if the object is an instance of, or inherits from, Array.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <returns>True if the object is an instance of or inherits from Array.</returns>
    public static bool IsInstanceOfArray(object obj)
    {
        return obj is Array;
    }
}
