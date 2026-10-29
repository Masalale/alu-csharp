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

/// <summary>Interactive interface.</summary>
public interface IInteractive
{
    /// <summary>Interacts with the object.</summary>
    void Interact();
}

/// <summary>Breakable interface.</summary>
public interface IBreakable
{
    /// <summary>Gets or sets the durability.</summary>
    int durability { get; set; }

    /// <summary>Breaks the object.</summary>
    void Break();
}

/// <summary>Collectable interface.</summary>
public interface ICollectable
{
    /// <summary>Gets or sets whether the object is collected.</summary>
    bool isCollected { get; set; }

    /// <summary>Collects the object.</summary>
    void Collect();
}

/// <summary>TestObject class inheriting Base and all 3 interfaces.</summary>
public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    /// <summary>Gets or sets durability.</summary>
    public int durability { get; set; }

    /// <summary>Gets or sets whether collected.</summary>
    public bool isCollected { get; set; }

    /// <summary>Interacts with object.</summary>
    public void Interact() {}

    /// <summary>Breaks object.</summary>
    public void Break() {}

    /// <summary>Collects object.</summary>
    public void Collect() {}
}
