using GGUFReader.Factories;
using GGUFReader.Services;
using Moq;

namespace GGUFReader.Tests.Factories;

[TestFixture]
public class LlamaModelServiceFactoryTests
{
    private Mock<IServiceProvider> _serviceProviderMock;
    private LlamaModelServiceFactory _factory;

    [SetUp]
    public void SetUp()
    {
        _serviceProviderMock = new Mock<IServiceProvider>();
        _factory = new LlamaModelServiceFactory(_serviceProviderMock.Object);
    }

    [Test]
    public void Constructor_ShouldInitializeFactory()
    {
        // Act & Assert
        Assert.That(_factory, Is.Not.Null);
    }

    [Test]
    public void Create_ShouldReturnLlamaModelServiceInstance()
    {
        // Arrange
        string folderPath = "testFolderPath";
        string modelName = "testModelName";

        // Act
        var service = _factory.Create(folderPath, modelName);

        // Assert
        Assert.That(service, Is.Not.Null);
        Assert.That(service, Is.InstanceOf<LlamaModelService>());
    }
}

