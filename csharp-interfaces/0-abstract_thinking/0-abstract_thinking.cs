using System;

/// <summary>Abstract base class.</summary>
public abstract class Base
{
    /// <summary>Gets or sets the name.</summary>
    public string name { get; set; }

    /// <summary>Returns formatted string of name and type.</summary>
    public override string ToString()
    {
        return $"{this.name} is a {this.GetType().Name}";
    }
}
