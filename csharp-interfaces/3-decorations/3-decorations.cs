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

/// <summary>Decoration class inheriting Base, IInteractive, and IBreakable.</summary>
public class Decoration : Base, IInteractive, IBreakable
{
    /// <summary>Indicates whether decoration is a quest item.</summary>
    public bool isQuestItem;

    /// <summary>Gets or sets durability.</summary>
    public int durability { get; set; }

    /// <summary>Initializes a new instance of the Decoration class.</summary>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability <= 0)
        {
            throw new Exception("Durability must be greater than 0");
        }

        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    /// <summary>Interacts with the decoration.</summary>
    public void Interact()
    {
        if (this.durability <= 0)
        {
            Console.WriteLine($"The {this.name} has been broken.");
        }
        else if (this.isQuestItem)
        {
            Console.WriteLine($"You look at the {this.name}. There's a key inside.");
        }
        else
        {
            Console.WriteLine($"You look at the {this.name}. Not much to see here.");
        }
    }

    /// <summary>Breaks the decoration, decrementing durability.</summary>
    public void Break()
    {
        this.durability--;

        if (this.durability > 0)
        {
            Console.WriteLine($"You hit the {this.name}. It cracks.");
        }
        else if (this.durability == 0)
        {
            Console.WriteLine($"You smash the {this.name}. What a mess.");
        }
        else
        {
            Console.WriteLine($"The {this.name} is already broken.");
        }
    }
}
