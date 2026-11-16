using System;
using System.Text.Json.Serialization;

namespace InventoryLibrary;

/// <summary>
/// Represents a user who owns inventory entries.
/// Inherits a unique id and timestamps from <see cref="BaseClass"/>.
/// </summary>
public class User : BaseClass
{
    // Backing field for the required name, kept non-blank.
    private string _name = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// The name is required and must have a value on creation.
    /// </summary>
    /// <param name="name">The required name of the user.</param>
    /// <exception cref="ArgumentException">Thrown when name is null or whitespace.</exception>
    [JsonConstructor]
    public User(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

        this.name = name;
    }

    /// <summary>
    /// Gets or sets the required name of the user. Cannot be blank.
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
    /// Returns a short, readable representation of the user.
    /// </summary>
    /// <returns>A one-line string with the class name, id and main property.</returns>
    public override string ToString()
    {
        return $"User(id={id}, name={name})";
    }
}
