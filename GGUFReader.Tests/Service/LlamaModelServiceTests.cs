﻿using GGUFReader.Services;
using LLama.Abstractions;
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

        var inferenceParams = new Mock<IInferenceParams>();
        var executor = new Mock<ILLamaExecutor>();
        var inferenceParamsService = new Mock<IInferenceParamsService>();
        var responseList = new List<string> { expectedResponse };
        var asyncEnumerable = GetAsyncEnumerable(responseList);

        inferenceParamsService.Setup(s => s.GetDefaultParams()).Returns(inferenceParams.Object);
        executor.Setup(e => e.InferAsync(prompt, inferenceParams.Object, default)).Returns(asyncEnumerable);

        var service = new LlamaModelService(executor.Object, inferenceParamsService.Object);

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
        var executor = new Mock<ILLamaExecutor>();
        var inferenceParamsService = new Mock<IInferenceParamsService>();
        var service = new LlamaModelService(executor.Object, inferenceParamsService.Object);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(() => service.GenerateResponseAsync(null));
        Assert.ThrowsAsync<ArgumentException>(() => service.GenerateResponseAsync(""));

        // Verify
        executor.Verify(e => e.InferAsync(It.IsAny<string>(), It.IsAny<IInferenceParams>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    private static async IAsyncEnumerable<string> GetAsyncEnumerable(List<string> list)
    {
        foreach (var item in list)
        {
            yield return await Task.FromResult(item);
        }
    }
}