using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryLibrary;

/// <summary>
/// Persists inventory objects to and from a JSON file. Objects are kept in
/// memory in a dictionary keyed by &lt;ClassName&gt;.&lt;id&gt; and can be
/// serialized to disk with <see cref="Save"/> and restored with <see cref="Load"/>.
/// </summary>
public class JSONStorage
{
    // In-memory store of objects keyed by "<ClassName>.<id>".
    private Dictionary<string, BaseClass> objects = new Dictionary<string, BaseClass>();

    // Shared serializer options: pretty-printed JSON for readability on disk.
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    /// <summary>
    /// Returns the dictionary of stored objects keyed by &lt;ClassName&gt;.&lt;id&gt;.
    /// </summary>
    /// <returns>The objects dictionary.</returns>
    public Dictionary<string, BaseClass> All()
    {
        return objects;
    }

    /// <summary>
    /// Adds a new object to the store using &lt;obj ClassName&gt;.&lt;obj id&gt; as its key.
    /// An existing entry with the same key is overwritten.
    /// </summary>
    /// <param name="obj">The object to store. Cannot be null.</param>
    public void New(BaseClass obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        string key = obj.GetType().Name + "." + obj.id;
        objects[key] = obj;
    }

    /// <summary>
    /// Serializes the stored objects to the JSON file located in the storage directory.
    /// The storage directory is created if it does not already exist.
    /// </summary>
    public void Save()
    {
        // Serialize through Dictionary<string, object> so System.Text.Json uses each
        // value's runtime type. Serializing as BaseClass would drop the properties
        // declared on Item, User and Inventory.
        Dictionary<string, object> values = new Dictionary<string, object>();
        foreach (KeyValuePair<string, BaseClass> pair in objects)
        {
            values[pair.Key] = pair.Value;
        }

        string json = JsonSerializer.Serialize(values, SerializerOptions);

        string path = GetFilePath();
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        File.WriteAllText(path, json);
    }

    /// <summary>
    /// Loads objects from the JSON file into the store. If the file does not
    /// exist, this method does nothing. Each key's class-name prefix determines
    /// the concrete type used when deserializing the stored value.
    /// </summary>
    public void Load()
    {
        string path = GetFilePath();
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        using JsonDocument document = JsonDocument.Parse(json);

        objects.Clear();

        foreach (JsonProperty property in document.RootElement.EnumerateObject())
        {
            string key = property.Name;

            // The key format is "<ClassName>.<id>"; the part before the first
            // dot is the discriminator used to pick the concrete type.
            int separator = key.IndexOf('.');
            if (separator < 0)
                continue;

            string className = key.Substring(0, separator);
            BaseClass? value = null;

            switch (className)
            {
                case "Item":
                    value = property.Value.Deserialize<Item>(SerializerOptions);
                    break;
                case "User":
                    value = property.Value.Deserialize<User>(SerializerOptions);
                    break;
                case "Inventory":
                    value = property.Value.Deserialize<Inventory>(SerializerOptions);
                    break;
            }

            if (value != null)
                objects[key] = value;
        }
    }

    // Walks up from the current directory to find the ancestor that contains
    // InventoryManagement.sln, so storage resolves whether the app is launched
    // from the solution folder or from the InventoryManager folder.
    private static string GetFilePath()
    {
        DirectoryInfo? directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory != null)
        {
            string solutionPath = Path.Combine(directory.FullName, "InventoryManagement.sln");
            if (File.Exists(solutionPath))
                return Path.Combine(directory.FullName, "InventoryLibrary", "storage", "inventory_manager.json");

            directory = directory.Parent;
        }

        // No solution file found: fall back to the current working directory.
        return Path.Combine(Directory.GetCurrentDirectory(), "InventoryLibrary", "storage", "inventory_manager.json");
    }
}
