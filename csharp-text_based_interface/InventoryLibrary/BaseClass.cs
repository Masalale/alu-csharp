using System;

namespace InventoryLibrary;

/// <summary>
/// Base class that all inventory classes inherit from. Provides a unique
/// identifier and timestamps tracking when an object was created and last updated.
/// </summary>
public class BaseClass
{
    /// <summary>
    /// Gets or sets the unique identifier for this object.
    /// </summary>
    public string id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// Gets or sets the date and time when this object was created.
    /// </summary>
    public DateTime date_created { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the date and time when this object was last updated.
    /// </summary>
    public DateTime date_updated { get; set; } = DateTime.Now;
}
