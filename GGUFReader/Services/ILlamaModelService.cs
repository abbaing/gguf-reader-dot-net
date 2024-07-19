using GGUFReader.Models;

namespace GGUFReader.Services;

public interface ILlamaModelService
{
    Task<string> GenerateResponseAsync(string prompt, ILlamaInferenceParams? inferenceParams = null);
}
