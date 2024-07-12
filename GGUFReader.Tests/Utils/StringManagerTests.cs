using GGUFReader.Utils;

namespace GGUFReader.Tests.Utils;

[TestFixture]
public class StringManagerTests
{
    [Test]
    public async Task AsyncAppend_WithMultipleStrings_ReturnsConcatenatedString()
    {
        // Arrange
        var strings = new List<string> { "Hello", " ", "World", "!" };
        var asyncStrings = GetAsyncStrings(strings);

        // Act
        var result = await StringManager.AsyncAppend(asyncStrings);

        // Assert
        Assert.That(result, Is.EqualTo("Hello World!"));
    }

    [Test]
    public async Task AsyncAppend_WithEmptyEnumerable_ReturnsEmptyString()
    {
        // Arrange
        var strings = new List<string> { };
        var asyncStrings = GetAsyncStrings(strings);

        // Act
        var result = await StringManager.AsyncAppend(asyncStrings);

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public async Task AsyncAppend_WithSingleString_ReturnsSameString()
    {
        // Arrange
        var strings = new List<string> { "Hello" };
        var asyncStrings = GetAsyncStrings(strings);

        // Act
        var result = await StringManager.AsyncAppend(asyncStrings);

        // Assert
        Assert.That(result, Is.EqualTo("Hello"));
    }

    private static async IAsyncEnumerable<string> GetAsyncStrings(IEnumerable<string> strings)
    {
        foreach (var s in strings)
        {
            yield return s;
            await Task.Yield();
        }
    }
}