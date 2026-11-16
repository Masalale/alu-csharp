using System;
using System.Collections.Generic;
using InventoryLibrary;
using NUnit.Framework;

namespace InventoryManagement.Tests;

/// <summary>
/// Tests for the shared behaviour that <see cref="BaseClass"/> gives every
/// inventory object: a unique identifier and creation/update timestamps.
/// </summary>
[TestFixture]
public class BaseClassTests
{
    /// <summary>
    /// Verifies that every newly constructed object receives a non-empty,
    /// well-formed GUID identifier.
    /// </summary>
    [Test]
    public void NewObject_HasNonEmptyGuidId()
    {
        var item = new Item("Widget");
        var user = new User("Ada");
        var inventory = new Inventory(user.id, item.id);

        Assert.That(item.id, Is.Not.Null.And.Not.Empty);
        Assert.That(user.id, Is.Not.Null.And.Not.Empty);
        Assert.That(inventory.id, Is.Not.Null.And.Not.Empty);
        Assert.That(Guid.TryParse(item.id, out _), Is.True, "Item id is not a GUID.");
        Assert.That(Guid.TryParse(user.id, out _), Is.True, "User id is not a GUID.");
        Assert.That(Guid.TryParse(inventory.id, out _), Is.True, "Inventory id is not a GUID.");
    }

    /// <summary>
    /// Verifies that identifiers are unique across a large batch of objects.
    /// </summary>
    [Test]
    public void NewObjects_HaveUniqueIds()
    {
        var ids = new HashSet<string>();
        for (int i = 0; i < 50; i++)
            ids.Add(new Item("Item " + i).id);

        Assert.That(ids.Count, Is.EqualTo(50), "Expected 50 distinct ids.");
    }

    /// <summary>
    /// Verifies that creation and update timestamps are initialised to a
    /// sensible value at construction time.
    /// </summary>
    [Test]
    public void NewObject_HasTimestampsSet()
    {
        DateTime before = DateTime.Now;
        var item = new Item("Widget");
        DateTime after = DateTime.Now;

        Assert.That(item.date_created, Is.InRange(before, after));
        Assert.That(item.date_updated, Is.InRange(before, after));
    }
}
