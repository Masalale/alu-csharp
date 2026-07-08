using System;

/// <summary>
/// Provides methods for object type checking.
/// </summary>
class Obj
{
    /// <summary>
    /// Returns True if the object is an int, otherwise return False.
    /// </summary>
    /// <param name="obj">The object to check.</param>
    /// <returns>True if the object is an int, otherwise False.</returns>
    public static bool IsOfTypeInt(object obj)
    {
        return obj is int;
    }
}
