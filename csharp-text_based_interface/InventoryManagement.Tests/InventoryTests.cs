using System;
using InventoryLibrary;
using NUnit.Framework;

namespace InventoryManagement.Tests;

/// <summary>
/// Tests for the <see cref="Inventory"/> class, including id validation and
/// quantity edge cases.
/// </summary>
[TestFixture]
public class InventoryTests
{
    /// <summary>
    /// Verifies that a blank user id is rejected by the constructor.
    /// </summary>
    [Test]
    public void Constructor_BlankUserId_Throws()
    {
        foreach (string? bad in new string?[] { null, string.Empty, "   " })
        {
            string? value = bad;
            Action act = () => new Inventory(value!, "item-id");
            Assert.Throws<ArgumentException>(act);
        }
    }

    /// <summary>
    /// Verifies that a blank item id is rejected by the constructor.
    /// </summary>
    [Test]
    public void Constructor_BlankItemId_Throws()
    {
        foreach (string? bad in new string?[] { null, string.Empty, "   " })
        {
            string? value = bad;
            Action act = () => new Inventory("user-id", value!);
            Assert.Throws<ArgumentException>(act);
        }
    }

    /// <summary>
    /// Verifies that a new entry defaults to a quantity of one.
    /// </summary>
    [Test]
    public void Quantity_DefaultsToOne()
    {
        var inventory = new Inventory("user-id", "item-id");
        Assert.That(inventory.quantity, Is.EqualTo(1));
    }

    /// <summary>
    /// Verifies that a negative quantity is rejected and the value is unchanged.
    /// </summary>
    [Test]
    public void Quantity_Negative_Throws()
    {
        var inventory = new Inventory("user-id", "item-id");

        Action act = () => inventory.quantity = -1;
        Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.That(inventory.quantity, Is.EqualTo(1), "A failed assignment must not change the quantity.");
    }

    /// <summary>
    /// Verifies that valid quantities, including zero and the id setters, persist.
    /// </summary>
    [Test]
    public void ValidValues_Persist()
    {
        var inventory = new Inventory("user-id", "item-id");

        inventory.quantity = 0;
        Assert.That(inventory.quantity, Is.EqualTo(0));

        inventory.quantity = 42;
        Assert.That(inventory.quantity, Is.EqualTo(42));

        inventory.user_id = "new-user";
        inventory.item_id = "new-item";
        Assert.That(inventory.user_id, Is.EqualTo("new-user"));
        Assert.That(inventory.item_id, Is.EqualTo("new-item"));
    }

    /// <summary>
    /// Verifies that the id setters also reject blank values.
    /// </summary>
    [Test]
    public void IdSetters_RejectBlank()
    {
        var inventory = new Inventory("user-id", "item-id");

        Action blankUser = () => inventory.user_id = " ";
        Action blankItem = () => inventory.item_id = " ";
        Assert.Throws<ArgumentException>(blankUser);
        Assert.Throws<ArgumentException>(blankItem);
        Assert.That(inventory.user_id, Is.EqualTo("user-id"));
        Assert.That(inventory.item_id, Is.EqualTo("item-id"));
    }

    /// <summary>
    /// Verifies that the string representation surfaces both ids and the quantity.
    /// </summary>
    [Test]
    public void ToString_IncludesIdsAndQuantity()
    {
        var inventory = new Inventory("user-id", "item-id") { quantity = 7 };

        string text = inventory.ToString();
        Assert.That(text, Does.Contain(inventory.id));
        Assert.That(text, Does.Contain("user-id"));
        Assert.That(text, Does.Contain("item-id"));
        Assert.That(text, Does.Contain("7"));
    }
}
