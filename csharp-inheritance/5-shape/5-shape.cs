using System;

/// <summary>
/// Represents a shape.
/// </summary>
class Shape
{
    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    /// <returns>The area of the shape.</returns>
    /// <exception cref="NotImplementedException">Thrown because area calculation is not implemented.</exception>
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
}
