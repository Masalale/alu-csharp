using System;
using System.Collections.Generic;
using System.IO;
using InventoryLibrary;
using NUnit.Framework;

namespace InventoryManagement.Tests;

/// <summary>
/// Tests for <see cref="JSONStorage"/>. This fixture isolates the process
/// working directory to a unique temporary folder so that no test ever reads
/// or writes the repository's real storage file.
/// </summary>
[TestFixture]
[NonParallelizable]
public class JSONStorageTests
{
    private string _tempDir = string.Empty;
    private string _originalCwd = string.Empty;

    /// <summary>
    /// Gets the storage file path that <see cref="JSONStorage"/> resolves from
    /// the isolated working directory.
    /// </summary>
    private string StoragePath =>
        Path.Combine(_tempDir, "InventoryLibrary", "storage", "inventory_manager.json");

    /// <summary>
    /// Creates an isolated working directory containing a solution marker so
    /// the storage path resolves inside the temporary folder.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _originalCwd = Directory.GetCurrentDirectory();
        _tempDir = Path.Combine("/tmp/opencode", "invtests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
        File.WriteAllText(Path.Combine(_tempDir, "InventoryManagement.sln"), string.Empty);
        Directory.SetCurrentDirectory(_tempDir);
    }

    /// <summary>
    /// Restores the original working directory and removes the temporary folder.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        Directory.SetCurrentDirectory(_originalCwd);
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    /// <summary>
    /// Verifies that New() keys each object by its class name and id.
    /// </summary>
    [Test]
    public void New_UsesClassNameDotIdKey()
    {
        var storage = new JSONStorage();
        var item = new Item("Widget");
        var user = new User("Ada");
        var inventory = new Inventory(user.id, item.id);

        storage.New(item);
        storage.New(user);
        storage.New(inventory);

        Dictionary<string, BaseClass> all = storage.All();
        Assert.That(all.ContainsKey("Item." + item.id), Is.True);
        Assert.That(all.ContainsKey("User." + user.id), Is.True);
        Assert.That(all.ContainsKey("Inventory." + inventory.id), Is.True);
        Assert.That(all.Count, Is.EqualTo(3));
    }

    /// <summary>
    /// Verifies that All() exposes the live dictionary and that a duplicate key
    /// overwrites the earlier entry.
    /// </summary>
    [Test]
    public void All_ExposesDictionaryAndDuplicateOverwrites()
    {
        var storage = new JSONStorage();
        Dictionary<string, BaseClass> dict = storage.All();
        Assert.That(dict, Is.Not.Null.And.Empty);

        var first = new Item("First");
        var second = new Item("Second") { id = first.id };

        storage.New(first);
        storage.New(second);

        Assert.That(dict.Count, Is.EqualTo(1), "All() must return the live dictionary.");
        Assert.That(dict["Item." + first.id], Is.SameAs(second));
    }

    /// <summary>
    /// Verifies that New() rejects a null object.
    /// </summary>
    [Test]
    public void New_Null_Throws()
    {
        var storage = new JSONStorage();
        Action act = () => storage.New(null!);
        Assert.Throws<ArgumentNullException>(act);
    }

    /// <summary>
    /// Verifies that Save() followed by a fresh Load() restores all three
    /// concrete runtime types together with their values.
    /// </summary>
    [Test]
    public void SaveThenLoad_RestoresAllConcreteTypes()
    {
        var item = new Item("Hammer") { description = "A tool", price = 12.3456f };
        item.tags.Add("tool");
        item.tags.Add("metal");
        var user = new User("Ada");
        var inventory = new Inventory(user.id, item.id) { quantity = 3 };

        var saveStore = new JSONStorage();
        saveStore.New(item);
        saveStore.New(user);
        saveStore.New(inventory);
        saveStore.Save();

        Assert.That(File.Exists(StoragePath), Is.True);

        var loadStore = new JSONStorage();
        loadStore.Load();
        Dictionary<string, BaseClass> all = loadStore.All();

        Assert.That(all.Count, Is.EqualTo(3));
        Assert.That(all["Item." + item.id], Is.TypeOf<Item>());
        Assert.That(all["User." + user.id], Is.TypeOf<User>());
        Assert.That(all["Inventory." + inventory.id], Is.TypeOf<Inventory>());

        var loadedItem = (Item)all["Item." + item.id];
        var loadedUser = (User)all["User." + user.id];
        var loadedInventory = (Inventory)all["Inventory." + inventory.id];

        Assert.That(loadedItem.name, Is.EqualTo("Hammer"));
        Assert.That(loadedItem.description, Is.EqualTo("A tool"));
        Assert.That(loadedItem.price, Is.EqualTo(12.35f).Within(0.001f));
        Assert.That(loadedItem.tags, Is.EqualTo(new[] { "tool", "metal" }));
        Assert.That(loadedItem.id, Is.EqualTo(item.id));
        Assert.That(loadedUser.name, Is.EqualTo("Ada"));
        Assert.That(loadedUser.id, Is.EqualTo(user.id));
        Assert.That(loadedInventory.user_id, Is.EqualTo(user.id));
        Assert.That(loadedInventory.item_id, Is.EqualTo(item.id));
        Assert.That(loadedInventory.quantity, Is.EqualTo(3));
        Assert.That(loadedInventory.id, Is.EqualTo(inventory.id));
    }

    /// <summary>
    /// Verifies that Load() on a missing file is a no-op and leaves existing
    /// in-memory objects untouched.
    /// </summary>
    [Test]
    public void Load_MissingFile_IsNoOp()
    {
        var storage = new JSONStorage();
        var item = new Item("Widget");
        storage.New(item);

        Assert.That(File.Exists(StoragePath), Is.False, "Precondition: no storage file yet.");

        storage.Load();

        Assert.That(storage.All().Count, Is.EqualTo(1));
        Assert.That(storage.All().ContainsKey("Item." + item.id), Is.True);
    }

    /// <summary>
    /// Verifies that Save() creates the storage directory when it does not exist.
    /// </summary>
    [Test]
    public void Save_CreatesStorageDirectoryIfAbsent()
    {
        var storage = new JSONStorage();
        storage.New(new Item("Widget"));

        string directory = Path.GetDirectoryName(StoragePath)!;
        Assert.That(Directory.Exists(directory), Is.False, "Precondition: storage directory absent.");

        storage.Save();

        Assert.That(Directory.Exists(directory), Is.True);
        Assert.That(File.Exists(StoragePath), Is.True);
    }
}
