using InventoryLibrary;
using NUnit.Framework;

namespace InventoryManagement.Tests;

/// <summary>
/// Tests for the <see cref="Item"/> class, including input validation and
/// the optional properties.
/// </summary>
[TestFixture]
public class ItemTests
{
    /// <summary>
    /// Verifies that a null, empty, or whitespace name is rejected by the constructor.
    /// </summary>
    [Test]
    public void Constructor_BlankName_Throws()
    {
        foreach (string? bad in new string?[] { null, string.Empty, "   " })
        {
            string? value = bad;
            Action act = () => new Item(value!);
            Assert.Throws<ArgumentException>(act);
        }
    }

    /// <summary>
    /// Verifies that optional properties start with benign default values.
    /// </summary>
    [Test]
    public void OptionalProperties_HaveDefaults()
    {
        var item = new Item("Widget");

        Assert.That(item.name, Is.EqualTo("Widget"));
        Assert.That(item.description, Is.Empty);
        Assert.That(item.price, Is.EqualTo(0f));
        Assert.That(item.tags, Is.Empty);
    }

    /// <summary>
    /// Verifies that the price setter rounds values to two decimal places.
    /// </summary>
    /// <param name="input">The unrounded price.</param>
    /// <param name="expected">The expected rounded price.</param>
    [TestCase(5.678f, 5.68f)]
    [TestCase(12.3456f, 12.35f)]
    public void Price_RoundsToTwoDecimals(float input, float expected)
    {
        var item = new Item("Widget") { price = input };
        Assert.That(item.price, Is.EqualTo(expected).Within(0.001f));
    }

    /// <summary>
    /// Verifies that the tags collection is never null on a fresh item and
    /// can be populated freely.
    /// </summary>
    [Test]
    public void Tags_IsNeverNullByDefault()
    {
        var item = new Item("Widget");

        Assert.That(item.tags, Is.Not.Null);

        item.tags.Add("tool");
        item.tags.Add("metal");
        Assert.That(item.tags, Is.EqualTo(new[] { "tool", "metal" }));
    }

    /// <summary>
    /// Verifies that the name setter also rejects blank values.
    /// </summary>
    [Test]
    public void Name_SetterRejectsBlank()
    {
        var item = new Item("Widget");
        foreach (string? bad in new string?[] { null, string.Empty, "  \t" })
        {
            string? value = bad;
            Action act = () => item.name = value!;
            Assert.Throws<ArgumentException>(act);
        }

        Assert.That(item.name, Is.EqualTo("Widget"), "A failed assignment must not change the name.");
    }

    /// <summary>
    /// Verifies that the string representation surfaces the name and id.
    /// </summary>
    [Test]
    public void ToString_IncludesNameAndId()
    {
        var item = new Item("Hammer") { description = "A tool", price = 9.99f };
        item.tags.Add("tool");

        string text = item.ToString();
        Assert.That(text, Does.Contain("Hammer"));
        Assert.That(text, Does.Contain(item.id));
    }
}
