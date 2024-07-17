using GGUFReader.Utils;
using LLama.Abstractions;

namespace GGUFReader.Services;

public class LlamaModelService(ILLamaExecutor executor, IInferenceParamsService inferenceParamsService) : ILlamaModelService, IDisposable
{
    private bool _disposed;

    public async Task<string> GenerateResponseAsync(string? prompt, IInferenceParams? inferenceParams = null)
    {
        if (string.IsNullOrEmpty(prompt))
            throw new ArgumentException("Prompt cannot be null or empty.", nameof(prompt));

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
