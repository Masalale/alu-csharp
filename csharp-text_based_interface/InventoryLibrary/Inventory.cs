using System;
using System.Text.Json.Serialization;

namespace InventoryLibrary;

/// <summary>
/// Represents an inventory entry linking a user to an item with a quantity.
/// Inherits a unique id and timestamps from <see cref="BaseClass"/>.
/// </summary>
public class Inventory : BaseClass
{
    // Backing fields for the required ids, kept non-blank.
    private string _user_id = string.Empty;
    private string _item_id = string.Empty;

    // Backing field for the quantity, defaults to 1 and cannot be negative.
    private int _quantity = 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="Inventory"/> class.
    /// The user id and item id are required and must have values on creation.
    /// </summary>
    /// <param name="user_id">The required id of the user who owns this entry.</param>
    /// <param name="item_id">The required id of the item in this entry.</param>
    /// <exception cref="ArgumentException">Thrown when user_id or item_id is null or whitespace.</exception>
    [JsonConstructor]
    public Inventory(string user_id, string item_id)
    {
        if (string.IsNullOrWhiteSpace(user_id))
            throw new ArgumentException("User id cannot be null or whitespace.", nameof(user_id));
        if (string.IsNullOrWhiteSpace(item_id))
            throw new ArgumentException("Item id cannot be null or whitespace.", nameof(item_id));

        this.user_id = user_id;
        this.item_id = item_id;
    }

    /// <summary>
    /// Gets or sets the required id of the user who owns this inventory entry. Cannot be blank.
    /// </summary>
    public string user_id
    {
        get => _user_id;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("User id cannot be null or whitespace.", nameof(value));
            _user_id = value;
        }
    }

    /// <summary>
    /// Gets or sets the required id of the item in this inventory entry. Cannot be blank.
    /// </summary>
    public string item_id
    {
        get => _item_id;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Item id cannot be null or whitespace.", nameof(value));
            _item_id = value;
        }
    }

    /// <summary>
    /// Gets or sets the quantity of the item. Defaults to 1 and cannot be less than 0.
    /// </summary>
    public int quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Quantity cannot be less than 0.");
            _quantity = value;
        }
    }

    /// <summary>
    /// Returns a short, readable representation of the inventory entry.
    /// </summary>
    /// <returns>A one-line string with the class name, id and main properties.</returns>
    public override string ToString()
    {
        return $"Inventory(id={id}, user_id={user_id}, item_id={item_id}, quantity={quantity})";
    }
}
