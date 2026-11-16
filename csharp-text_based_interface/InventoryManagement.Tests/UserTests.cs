using InventoryLibrary;
using NUnit.Framework;

namespace InventoryManagement.Tests;

/// <summary>
/// Tests for the <see cref="User"/> class.
/// </summary>
[TestFixture]
public class UserTests
{
    /// <summary>
    /// Verifies that a null, empty, or whitespace name is rejected.
    /// </summary>
    [Test]
    public void Constructor_BlankName_Throws()
    {
        foreach (string? bad in new string?[] { null, string.Empty, "   " })
        {
            string? value = bad;
            Action act = () => new User(value!);
            Assert.Throws<ArgumentException>(act);
        }
    }

    /// <summary>
    /// Verifies that distinct users receive distinct identifiers.
    /// </summary>
    [Test]
    public void DistinctUsers_HaveDistinctIds()
    {
        var ada = new User("Ada");
        var grace = new User("Grace");

        Assert.That(ada.id, Is.Not.EqualTo(grace.id));
    }

    /// <summary>
    /// Verifies that a valid name is stored and the setter rejects blanks.
    /// </summary>
    [Test]
    public void Name_ValidValuePersistsAndBlankIsRejected()
    {
        var user = new User("Ada");
        Assert.That(user.name, Is.EqualTo("Ada"));

        Action blank = () => user.name = "   ";
        Assert.Throws<ArgumentException>(blank);
        Assert.That(user.name, Is.EqualTo("Ada"), "A failed assignment must not change the name.");

        user.name = "Ada Lovelace";
        Assert.That(user.name, Is.EqualTo("Ada Lovelace"));
    }

    /// <summary>
    /// Verifies that the string representation surfaces the name and id.
    /// </summary>
    [Test]
    public void ToString_IncludesNameAndId()
    {
        var user = new User("Ada");

        string text = user.ToString();
        Assert.That(text, Does.Contain("Ada"));
        Assert.That(text, Does.Contain(user.id));
    }
}
