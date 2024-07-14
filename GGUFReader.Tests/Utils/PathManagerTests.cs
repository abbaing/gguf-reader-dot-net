using GGUFReader.Utils;
using System.Reflection;

namespace GGUFReader.Tests.Utils;

[TestFixture]
public class PathManagerTests
{
    [Test]
    public void MainPath_IsInitializedCorrectly()
    {
        // Arrange & Act
        string mainPath = PathManager.MainPath;

        // Assert
        Assert.That(mainPath, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void MainPath_ThrowsExceptionWhenEntryAssemblyLocationIsNull()
    {
        // Arrange
        PathManager.SetEntryAssemblyLocationFunc(() => null);

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => { var path = PathManager.MainPath; });
        Assert.That(ex.Message, Is.EqualTo("Main Path cannot be retrieved"));

        // Clean up
        PathManager.SetEntryAssemblyLocationFunc(() => Assembly.GetEntryAssembly()?.Location);
    }

    [Test]
    public void GetModelPath_ReturnsCorrectPath()
    {
        // Arrange
        string folderPath = "GGUF";
        string modelName = "gpt2";
        string expectedPath = Path.Combine(PathManager.MainPath, folderPath, modelName);

        // Act
        string result = PathManager.GetModelPath(folderPath, modelName);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPath));
    }
}