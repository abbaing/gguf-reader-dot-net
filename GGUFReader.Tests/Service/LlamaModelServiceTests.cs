using GGUFReader.Factories;
using GGUFReader.Models;
using GGUFReader.Services;
using Moq;

namespace GGUFReader.Tests.Services.LlamaService;

[TestFixture]
public class LlamaModelServiceTests
{
    [Test]
    public async Task GenerateResponseAsync_ValidPrompt_CallsExecutorWithInferenceParams()
    {
        // Arrange
        var prompt = "test prompt";
        var expectedResponse = "response";

        var executorConfig = new Mock<LLamaExecutorConfiguration>();
        var executorFactory = new Mock<ILLamaModelExecutorFactory>();
        var executor = new Mock<ILLamaModelExecutor>();
        var inferenceParamsService = new Mock<IInferenceParamsService>();
        var inferenceParams = new Mock<ILlamaInferenceParams>();

        var responseList = new List<string> { expectedResponse };
        var asyncEnumerable = GetAsyncEnumerable(responseList);

        executorFactory.Setup(s => s.CreateExecutor(executorConfig.Object)).Returns(executor.Object);
        executor.Setup(e => e.InferAsync(prompt, inferenceParams.Object, default)).Returns(asyncEnumerable);
        inferenceParamsService.Setup(s => s.GetDefaultParams()).Returns(inferenceParams.Object);

        var service = new LlamaModelService(executorFactory.Object, executorConfig.Object, inferenceParamsService.Object);

        // Act
        var response = await service.GenerateResponseAsync(prompt);

        // Assert
        Assert.That(response, Is.EqualTo(expectedResponse));
        executor.Verify(e => e.InferAsync(prompt, inferenceParams.Object, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public void GenerateResponseAsync_NullOrEmptyPrompt_ThrowsArgumentException()
    {
        // Arrange
        var executorConfig = new Mock<LLamaExecutorConfiguration>();
        var executorFactory = new Mock<ILLamaModelExecutorFactory>();
        var executor = new Mock<ILLamaModelExecutor>();
        var inferenceParamsService = new Mock<IInferenceParamsService>();

        executorFactory.Setup(s => s.CreateExecutor(executorConfig.Object)).Returns(executor.Object);

        var service = new LlamaModelService(executorFactory.Object, executorConfig.Object, inferenceParamsService.Object);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => service.GenerateResponseAsync(null));
        Assert.ThrowsAsync<ArgumentException>(() => service.GenerateResponseAsync(""));

        // Verify
        executor.Verify(e => e.InferAsync(It.IsAny<string>(), It.IsAny<ILlamaInferenceParams>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    private static async IAsyncEnumerable<string> GetAsyncEnumerable(List<string> list)
    {
        foreach (var item in list)
        {
            yield return await Task.FromResult(item);
        }
    }
}
