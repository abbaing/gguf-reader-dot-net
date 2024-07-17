using LLama.Abstractions;

namespace GGUFReader.Services;

public interface ILlamaModelService
{
    Task<string> GenerateResponseAsync(string prompt, IInferenceParams? inferenceParams = null);
}
