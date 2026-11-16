# C# - Text-based Interface

This project covers building a text-based interface with a class library, inheritance, and JSON serialization in C#.

## Requirements

- All C# files compiled using `dotnet`
- Projects built with .NET 7 SDK

## Inventory Manager

`InventoryManager` is a console application that manages three kinds of objects stored by the
`InventoryLibrary` class library:

- **Item** — a product with a name, description, price and tags.
- **User** — a person who owns inventory entries.
- **Inventory** — links a user and an item with a quantity.

Objects are held in a single `JSONStorage` instance for the lifetime of the run and saved to
`InventoryLibrary/storage/inventory_manager.json` after every change, so data persists between
runs. Run it from this folder with:

```bash
dotnet run --project InventoryManager/InventoryManager.csproj
```

On start (and after every command) the app prints the available commands:

```
Inventory Manager -------------------------
<ClassNames> show all ClassNames of objects
<All> show all objects
<All [ClassName]> show all objects of a ClassName
<Create [ClassName]> a new object
<Show [ClassName object_id]> an object
<Update [ClassName object_id]> an object
<Delete [ClassName object_id]> an object
<Exit>
```

Command names and class names are case-insensitive.

- `ClassNames` lists `Item`, `User` and `Inventory`.
- `All` (optionally followed by a class name) prints the stored objects.
- `Create <ClassName>` asks for the object's properties in follow-up prompts. Creating an
  `Inventory` requires the ids of an existing `User` and `Item`.
- `Show <ClassName> <id>` prints one object.
- `Update <ClassName> <id>` prompts for each property; pressing Enter keeps the current value.
- `Delete <ClassName> <id>` asks for confirmation before removing the object.
- `Exit` ends the application (end-of-input does too).

Invalid class names produce `<name> is not a valid object type`; unknown ids produce
`Object <id> could not be found`.
