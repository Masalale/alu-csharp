using InventoryLibrary;

/// <summary>
/// Text-based command line interface for creating, viewing, updating and deleting
/// the objects persisted by <see cref="JSONStorage"/>. Objects are stored in memory
/// for the lifetime of the application and written back to disk after every change.
/// </summary>
public class InventoryManager
{
    // One shared store for the whole run: reading the file once at start-up and
    // reusing the same instance keeps every command working on the same in-memory
    // dictionary. Creating a new JSONStorage per command would lose earlier edits.
    private static readonly JSONStorage storage = new JSONStorage();

    /// <summary>
    /// Application entry point. Loads the persisted objects once and then runs the
    /// command loop until the user asks to Exit or the input stream ends.
    /// </summary>
    /// <param name="args">Command-line arguments; this application does not use them.</param>
    public static void Main(string[] args)
    {
        // Load once: all later commands read from and write to this same store.
        storage.Load();

        while (true)
        {
            PrintPrompt();

            string? line = Console.ReadLine();
            if (line == null) // end of input (e.g. piped stdin closed) behaves like Exit
                break;

            // Commands and options are whitespace separated; extra spaces are ignored.
            string[] parts = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
                continue; // blank line: simply show the prompt again

            string command = parts[0];

            if (command.Equals("Exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (command.Equals("ClassNames", StringComparison.OrdinalIgnoreCase))
            {
                if (parts.Length != 1)
                {
                    Console.WriteLine("Usage: ClassNames");
                    continue;
                }
                PrintClassNames();
                continue;
            }

            if (command.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                if (parts.Length > 2)
                {
                    Console.WriteLine("Usage: All [ClassName]");
                    continue;
                }
                if (parts.Length == 2)
                {
                    if (!TryGetClassName(parts[1], out string className))
                    {
                        Console.WriteLine($"{parts[1]} is not a valid object type");
                        continue;
                    }
                    PrintAll(className);
                }
                else
                {
                    PrintAll(null);
                }
                continue;
            }

            if (command.Equals("Create", StringComparison.OrdinalIgnoreCase))
            {
                if (parts.Length != 2)
                {
                    Console.WriteLine("Usage: Create <ClassName>");
                    continue;
                }
                if (!TryGetClassName(parts[1], out string className))
                {
                    Console.WriteLine($"{parts[1]} is not a valid object type");
                    continue;
                }
                CreateObject(className);
                continue;
            }

            if (command.Equals("Show", StringComparison.OrdinalIgnoreCase))
            {
                if (parts.Length != 3)
                {
                    Console.WriteLine("Usage: Show <ClassName> <id>");
                    continue;
                }
                if (!TryGetClassName(parts[1], out string className))
                {
                    Console.WriteLine($"{parts[1]} is not a valid object type");
                    continue;
                }
                ShowObject(className, parts[2]);
                continue;
            }

            if (command.Equals("Update", StringComparison.OrdinalIgnoreCase))
            {
                if (parts.Length != 3)
                {
                    Console.WriteLine("Usage: Update <ClassName> <id>");
                    continue;
                }
                if (!TryGetClassName(parts[1], out string className))
                {
                    Console.WriteLine($"{parts[1]} is not a valid object type");
                    continue;
                }
                UpdateObject(className, parts[2]);
                continue;
            }

            if (command.Equals("Delete", StringComparison.OrdinalIgnoreCase))
            {
                if (parts.Length != 3)
                {
                    Console.WriteLine("Usage: Delete <ClassName> <id>");
                    continue;
                }
                if (!TryGetClassName(parts[1], out string className))
                {
                    Console.WriteLine($"{parts[1]} is not a valid object type");
                    continue;
                }
                DeleteObject(className, parts[2]);
                continue;
            }

            Console.WriteLine($"Unknown command '{command}'. Type ClassNames to see the available commands.");
        }
    }

    // Prints the command list shown at start-up and after every completed command.
    private static void PrintPrompt()
    {
        Console.WriteLine("Inventory Manager -------------------------");
        Console.WriteLine("<ClassNames> show all ClassNames of objects");
        Console.WriteLine("<All> show all objects");
        Console.WriteLine("<All [ClassName]> show all objects of a ClassName");
        Console.WriteLine("<Create [ClassName]> a new object");
        Console.WriteLine("<Show [ClassName object_id]> an object");
        Console.WriteLine("<Update [ClassName object_id]> an object");
        Console.WriteLine("<Delete [ClassName object_id]> an object");
        Console.WriteLine("<Exit>");
    }

    // Case-insensitive alias to canonical class name. The caller reports an invalid name.
    private static bool TryGetClassName(string input, out string className)
    {
        if (input.Equals("Item", StringComparison.OrdinalIgnoreCase))
        {
            className = "Item";
            return true;
        }
        if (input.Equals("User", StringComparison.OrdinalIgnoreCase))
        {
            className = "User";
            return true;
        }
        if (input.Equals("Inventory", StringComparison.OrdinalIgnoreCase))
        {
            className = "Inventory";
            return true;
        }
        className = string.Empty;
        return false;
    }

    // Lists the class names managed by the app plus any found in loaded objects.
    private static void PrintClassNames()
    {
        HashSet<string> classNames = new HashSet<string> { "Item", "User", "Inventory" };
        foreach (BaseClass obj in storage.All().Values)
            classNames.Add(obj.GetType().Name);

        foreach (string className in classNames)
            Console.WriteLine(className);
    }

    // Prints every object, or only objects whose runtime type matches className.
    private static void PrintAll(string? className)
    {
        Dictionary<string, BaseClass> all = storage.All();
        bool found = false;

        foreach (BaseClass obj in all.Values)
        {
            if (className != null && obj.GetType().Name != className)
                continue;

            Console.WriteLine(obj.ToString());
            found = true;
        }

        if (!found)
            Console.WriteLine("No objects found.");
    }

    // Finds an object by its "<ClassName>.<id>" key and prints its representation.
    private static void ShowObject(string className, string id)
    {
        if (!storage.All().TryGetValue($"{className}.{id}", out BaseClass? obj))
        {
            Console.WriteLine($"Object {id} could not be found");
            return;
        }
        Console.WriteLine(obj.ToString());
    }

    // Dispatches creation to the branch for the requested class.
    private static void CreateObject(string className)
    {
        switch (className)
        {
            case "Item":
                CreateItem();
                break;
            case "User":
                CreateUser();
                break;
            case "Inventory":
                CreateInventory();
                break;
        }
    }

    // Reads a value, re-prompting until the user enters something non-blank.
    private static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            Console.WriteLine("Value cannot be blank.");
        }
    }

    // Reads a comma-separated list and drops empty entries after trimming.
    private static List<string> ReadTags(string input)
    {
        List<string> tags = new List<string>();
        foreach (string tag in input.Split(','))
        {
            string trimmed = tag.Trim();
            if (trimmed.Length > 0)
                tags.Add(trimmed);
        }
        return tags;
    }

    // Reads an id that must already exist as "<className>.<id>" in the store.
    // In create mode (current == null) a blank answer cancels; in update mode it
    // keeps the current id. Unknown ids are reported and re-prompted.
    private static string? ReadExistingId(string className, string prompt, string? current = null)
    {
        while (true)
        {
            Console.Write(current == null ? $"{prompt}: " : $"{prompt} [{current}]: ");
            string? value = Console.ReadLine();
            if (value == null)
                return current; // EOF: cancel in create mode, keep current in update mode

            value = value.Trim();
            if (value.Length == 0)
                return current;

            if (storage.All().ContainsKey($"{className}.{value}"))
                return value;

            Console.WriteLine($"Object {value} could not be found");
        }
    }

    private static void CreateItem()
    {
        string name = ReadRequired("Name: ");

        Console.Write("Description (optional): ");
        string description = Console.ReadLine() ?? string.Empty;

        Console.Write("Price (optional): ");
        string? priceInput = Console.ReadLine();
        float price = 0;
        if (!string.IsNullOrWhiteSpace(priceInput) && !float.TryParse(priceInput, out price))
        {
            Console.WriteLine("Invalid price.");
            price = 0;
        }

        Console.Write("Tags (optional, comma-separated): ");
        string? tagsInput = Console.ReadLine();
        List<string> tags = string.IsNullOrWhiteSpace(tagsInput)
            ? new List<string>()
            : ReadTags(tagsInput);

        Item item = new Item(name) { description = description, price = price, tags = tags };
        storage.New(item);
        // Save after the mutation so the new object survives a restart.
        storage.Save();
        Console.WriteLine($"Created Item with id {item.id}.");
    }

    private static void CreateUser()
    {
        string name = ReadRequired("Name: ");

        User user = new User(name);
        storage.New(user);
        storage.Save();
        Console.WriteLine($"Created User with id {user.id}.");
    }

    private static void CreateInventory()
    {
        string? userId = ReadExistingId("User", "User id");
        if (userId == null)
            return;
        string? itemId = ReadExistingId("Item", "Item id");
        if (itemId == null)
            return;

        Console.Write("Quantity (optional, default 1): ");
        string? quantityInput = Console.ReadLine();
        int quantity = 1;
        if (!string.IsNullOrWhiteSpace(quantityInput))
        {
            if (!int.TryParse(quantityInput, out quantity))
            {
                Console.WriteLine("Invalid quantity.");
                quantity = 1;
            }
            else if (quantity < 0)
            {
                Console.WriteLine("Quantity cannot be less than 0.");
                quantity = 1;
            }
        }

        Inventory inv = new Inventory(userId, itemId) { quantity = quantity };
        storage.New(inv);
        storage.Save();
        Console.WriteLine($"Created Inventory with id {inv.id}.");
    }

    // Prompts with the current value in brackets; Enter (or a blank answer) keeps it.
    private static string ReadValue(string prompt, string current)
    {
        Console.Write($"{prompt} [{current}]: ");
        string? value = Console.ReadLine();
        return string.IsNullOrWhiteSpace(value) ? current : value.Trim();
    }

    // Applies new values through the public setters and persists the change.
    private static void UpdateObject(string className, string id)
    {
        if (!storage.All().TryGetValue($"{className}.{id}", out BaseClass? obj))
        {
            Console.WriteLine($"Object {id} could not be found");
            return;
        }

        if (obj is Item item)
            UpdateItem(item);
        else if (obj is User user)
            UpdateUser(user);
        else if (obj is Inventory inv)
            UpdateInventory(inv);

        obj.date_updated = DateTime.Now;
        // Save after the mutation so updated values survive a restart.
        storage.Save();
        Console.WriteLine($"Object {id} updated.");
    }

    private static void UpdateItem(Item item)
    {
        item.name = ReadValue("Name", item.name);
        item.description = ReadValue("Description", item.description);

        Console.Write($"Price [{item.price}]: ");
        string? priceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(priceInput))
        {
            if (float.TryParse(priceInput, out float price))
                item.price = price; // setter rounds to two decimal places
            else
                Console.WriteLine("Invalid price.");
        }

        Console.Write($"Tags [{string.Join(",", item.tags)}]: ");
        string? tagsInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(tagsInput))
            item.tags = ReadTags(tagsInput);
    }

    private static void UpdateUser(User user)
    {
        user.name = ReadValue("Name", user.name);
    }

    private static void UpdateInventory(Inventory inv)
    {
        inv.user_id = ReadExistingId("User", "User id", inv.user_id) ?? inv.user_id;
        inv.item_id = ReadExistingId("Item", "Item id", inv.item_id) ?? inv.item_id;

        Console.Write($"Quantity [{inv.quantity}]: ");
        string? quantityInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(quantityInput))
        {
            if (!int.TryParse(quantityInput, out int quantity))
                Console.WriteLine("Invalid quantity.");
            else if (quantity < 0)
                Console.WriteLine("Quantity cannot be less than 0.");
            else
                inv.quantity = quantity;
        }
    }

    // Confirms before removing an object, then saves the shortened store.
    private static void DeleteObject(string className, string id)
    {
        string key = $"{className}.{id}";
        if (!storage.All().ContainsKey(key))
        {
            Console.WriteLine($"Object {id} could not be found");
            return;
        }

        Console.Write("Delete this object? (y/N): ");
        string? answer = Console.ReadLine();
        if (answer == null || !answer.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Delete cancelled.");
            return;
        }

        storage.All().Remove(key);
        // Save after the mutation so the deletion survives a restart.
        storage.Save();
        Console.WriteLine($"Object {id} deleted.");
    }
}
