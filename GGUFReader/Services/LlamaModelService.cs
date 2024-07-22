using GGUFReader.Factories;
using GGUFReader.Models;
using GGUFReader.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace GGUFReader.Services;

public class LlamaModelService(string folderPath, string modelName, IServiceProvider serviceProvider) : ILlamaModelService, IDisposable
{
    private bool _disposed;

    public async Task<string> GenerateResponseAsync(string? prompt, ILlamaInferenceParams? inferenceParams = null)
    {
        string modelPath = PathManager.GetModelPath(folderPath, modelName);

        LLamaExecutorConfiguration config = new()
        {
            Path = modelPath,
            ModelName = modelName
        };

        IInferenceParamsService inferenceParamsService = serviceProvider.GetRequiredService<IInferenceParamsService>();
        ILLamaModelExecutorFactory executorFactory = serviceProvider.GetRequiredService<ILLamaModelExecutorFactory>();

        if (string.IsNullOrEmpty(prompt))
            throw new ArgumentException("Prompt cannot be null or empty.", nameof(prompt));

        ILLamaModelExecutor executor = executorFactory.CreateExecutor(config);

        var response = executor.InferAsync(prompt, inferenceParams ?? inferenceParamsService.GetDefaultParams());
        return await StringManager.AsyncAppend(response);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
