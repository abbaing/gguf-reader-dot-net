using GGUFReader.Factories;
using GGUFReader.Models;
using GGUFReader.Services;
using Moq;

namespace GGUFReader.Tests.Services.LlamaService;

[TestFixture]
public class LlamaModelServiceTests
{
    private Mock<IServiceProvider> _serviceProviderMock;
    private Mock<IInferenceParamsService> _inferenceParamsServiceMock;
    private Mock<ILLamaModelExecutorFactory> _executorFactoryMock;
    private Mock<ILLamaModelExecutor> _executorMock;
    private LlamaModelService _llamaModelService;

    [SetUp]
    public void SetUp()
    {
        _serviceProviderMock = new Mock<IServiceProvider>();
        _inferenceParamsServiceMock = new Mock<IInferenceParamsService>();
        _executorFactoryMock = new Mock<ILLamaModelExecutorFactory>();
        _executorMock = new Mock<ILLamaModelExecutor>();

        _serviceProviderMock.Setup(sp => sp.GetService(typeof(IInferenceParamsService))).Returns(_inferenceParamsServiceMock.Object);
        _serviceProviderMock.Setup(sp => sp.GetService(typeof(ILLamaModelExecutorFactory))).Returns(_executorFactoryMock.Object);

        _executorFactoryMock.Setup(factory => factory.CreateExecutor(It.IsAny<LLamaExecutorConfiguration>())).Returns(_executorMock.Object);

        _llamaModelService = new LlamaModelService("testFolderPath", "testModelName", _serviceProviderMock.Object);
    }

    [TearDown]
    public void Dispose()
    {
        _llamaModelService.Dispose();
    }

    [Test]
    public void Constructor_ShouldInitializeFields()
    {
        // Act & Assert
        Assert.That(_llamaModelService, Is.Not.Null);
    }

    [Test]
    public void GenerateResponseAsync_WithNullPrompt_ShouldThrowArgumentException()
    {
        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () =>
            await _llamaModelService.GenerateResponseAsync(null));
    }

    [Test]
    public void GenerateResponseAsync_WithEmptyPrompt_ShouldThrowArgumentException()
    {
        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () =>
            await _llamaModelService.GenerateResponseAsync(string.Empty));
    }

    [Test]
    public async Task GenerateResponseAsync_WithValidPrompt_ShouldCallExecutorInferAsync()
    {
        // Arrange
        string testPrompt = "test prompt";
        string expectedResponse = "test response";
        var responseList = new List<string> { expectedResponse };
        var asyncEnumerable = GetAsyncEnumerable(responseList);
        var inferenceParams = new Mock<ILlamaInferenceParams>();

        _executorMock.Setup(e => e.InferAsync(testPrompt, inferenceParams.Object, default)).Returns(asyncEnumerable);

        // Act
        var result = await _llamaModelService.GenerateResponseAsync(testPrompt, inferenceParams.Object);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        _executorMock.Verify(e => e.InferAsync(testPrompt, inferenceParams.Object, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GenerateResponseAsync_WithNullInferenceParams_ShouldUseDefaultParams()
    {
        // Arrange
        string testPrompt = "test prompt";
        string expectedResponse = "test response";
        var responseList = new List<string> { expectedResponse };
        var asyncEnumerable = GetAsyncEnumerable(responseList);
        var defaultParams = new Mock<ILlamaInferenceParams>();

        _inferenceParamsServiceMock.Setup(service => service.GetDefaultParams()).Returns(defaultParams.Object);
        _executorMock.Setup(e => e.InferAsync(testPrompt, defaultParams.Object, default)).Returns(asyncEnumerable);

        // Act
        var result = await _llamaModelService.GenerateResponseAsync(testPrompt);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResponse));
        _executorMock.Verify(e => e.InferAsync(testPrompt, defaultParams.Object, It.IsAny<CancellationToken>()), Times.Once);
    }

    private static async IAsyncEnumerable<string> GetAsyncEnumerable(List<string> list)
    {
        foreach (var item in list)
        {
            yield return await Task.FromResult(item);
        }
    }
}
