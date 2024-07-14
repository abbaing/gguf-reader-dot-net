using GGUFReader.Services;
using LLama.Abstractions;
using LLama.Common;
using Moq;

namespace GGUFReader.Tests.Service;

[TestFixture]
public class GGUFServiceTests
{
    [Test]
    public async Task GenerateResponse_ReturnsCorrectResponse()
    {
        // Arrange
        string prompt = "Hello";
        string expectedResponse = "Generated response";

        // Mocks
        var mockExecutor = new Mock<ILLamaExecutor>();
        mockExecutor
            .Setup(e => e.InferAsync(
                It.IsAny<string>(), 
                It.IsAny<IInferenceParams>(), 
                It.IsAny<CancellationToken>()
            ))
            .Returns(GetAsyncEnumerable(["Generated", " ", "response"]));

        var serviceParams = new GGUFServiceParams(128, MirostatType.Mirostat2, 10, 0.7f);
        var service = new GGUFService(mockExecutor.Object, serviceParams);

        // Act
        var response = await service.GenerateResponse(prompt);

        // Assert
        Assert.That(response, Is.EqualTo(expectedResponse));
    }

    private static async IAsyncEnumerable<string> GetAsyncEnumerable(List<string> list)
    {
        foreach (var item in list)
        {
            yield return await Task.FromResult(item);
        }
    }
}