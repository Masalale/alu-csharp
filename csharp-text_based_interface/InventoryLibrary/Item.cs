using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InventoryLibrary;

/// <summary>
/// Represents an item that can be stored in an inventory.
/// Inherits a unique id and timestamps from <see cref="BaseClass"/>.
/// </summary>
public class Item : BaseClass
{
    // Backing field for the required name, kept non-blank.
    private string _name = string.Empty;

    // Backing field for the price, rounded to two decimal places.
    private float _price;

    /// <summary>
    /// Initializes a new instance of the <see cref="Item"/> class.
    /// The name is required and must have a value on creation.
    /// </summary>
    /// <param name="name">The required name of the item.</param>
    /// <exception cref="ArgumentException">Thrown when name is null or whitespace.</exception>
    [JsonConstructor]
    public Item(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

        this.name = name;
    }

    /// <summary>
    /// Gets or sets the required name of the item. Cannot be blank.
    /// </summary>
    public string name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(value));
            _name = value;
        }
    }

    /// <summary>
    /// Gets or sets an optional description of the item.
    /// </summary>
    public string description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the optional price of the item, rounded to two decimal places.
    /// </summary>
    public float price
    {
        get => _price;
        set => _price = (float)Math.Round(value, 2);
    }

    /// <summary>
    /// Gets or sets the optional list of tags for the item. Never null.
    /// </summary>
    public List<string> tags { get; set; } = new List<string>();

    /// <summary>
    /// Returns a short, readable representation of the item.
    /// </summary>
    /// <returns>A one-line string with the class name, id and main properties.</returns>
    public override string ToString()
    {
        return $"Item(id={id}, name={name}, description={description}, price={price}, tags={string.Join(",", tags)})";
    }
}
