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

/// <summary>Door class inheriting Base and IInteractive.</summary>
public class Door : Base, IInteractive
{
    /// <summary>Initializes a new instance of the Door class.</summary>
    public Door(string name = "Door")
    {
        this.name = name;
    }

    /// <summary>Interacts with the door.</summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {this.name}. It's locked.");
    }
}
