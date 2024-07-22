using GGUFReader.Factories;
using GGUFReader.Models;

namespace GGUFReader.Tests.Factories;

public class LlamaModelExecutorFactoryTests
{
    [Test]
    public void CreateExecutor_PathIsNull_ThrowsNullPathException()
    {
        // Arrange
        var factory = new LLamaModelExecutorFactory();
        var config = new LLamaExecutorConfiguration { Path = null };

        // Act & Assert
        Assert.Throws<LLamaModelExecutorFactory.NullPathException>(() => factory.CreateExecutor(config));
    }

    [Test]
    public void CreateExecutor_PathIsEmpty_ThrowsNullPathException()
    {
        // Arrange
        var factory = new LLamaModelExecutorFactory();
        var config = new LLamaExecutorConfiguration { Path = string.Empty };

        // Act & Assert
        Assert.Throws<LLamaModelExecutorFactory.NullPathException>(() => factory.CreateExecutor(config));
    }

    [Test]
    public void CreateExecutor_PathIsWhitespace_ThrowsNullPathException()
    {
        // Arrange
        var factory = new LLamaModelExecutorFactory();
        var config = new LLamaExecutorConfiguration { Path = "   " };

        // Act & Assert
        Assert.Throws<LLamaModelExecutorFactory.NullPathException>(() => factory.CreateExecutor(config));
    }
}
