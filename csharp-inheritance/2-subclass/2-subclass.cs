using System;

/// <summary>
/// Provides methods for type hierarchy checking.
/// </summary>
class Obj
{
    /// <summary>
    /// Returns True if the object is a subclass of the specified base class.
    /// </summary>
    /// <param name="derivedType">The derived type to check.</param>
    /// <param name="baseType">The base type.</param>
    /// <returns>True if derivedType is a subclass of baseType (not the same type).</returns>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        return derivedType.IsSubclassOf(baseType);
    }
}
