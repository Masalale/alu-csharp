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

/// <summary>
/// Represents a rectangle, inheriting from Shape.
/// </summary>
class Rectangle : Shape
{
    private int width;
    private int height;

    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    public int Width
    {
        get { return width; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Width must be greater than or equal to 0");
            width = value;
        }
    }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    public int Height
    {
        get { return height; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Height must be greater than or equal to 0");
            height = value;
        }
    }

    /// <summary>
    /// Calculates the area of the rectangle.
    /// </summary>
    /// <returns>Width * Height.</returns>
    public new int Area()
    {
        return width * height;
    }

    /// <summary>
    /// Returns a string representation of the rectangle.
    /// </summary>
    /// <returns>[Rectangle] &lt;width&gt; / &lt;height&gt;</returns>
    public override string ToString()
    {
        return $"[Rectangle] {width} / {height}";
    }
}

/// <summary>
/// Represents a square, inheriting from Rectangle.
/// </summary>
class Square : Rectangle
{
    private int size;

    /// <summary>
    /// Gets or sets the size of the square.
    /// </summary>
    public int Size
    {
        get { return size; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Size must be greater than or equal to 0");
            size = value;
            Width = value;
            Height = value;
        }
    }

    /// <summary>
    /// Returns a string representation of the square.
    /// </summary>
    /// <returns>[Square] &lt;size&gt; / &lt;size&gt;</returns>
    public override string ToString()
    {
        return $"[Square] {size} / {size}";
    }
}
