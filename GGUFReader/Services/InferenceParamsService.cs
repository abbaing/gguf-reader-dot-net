using GGUFReader.Models;
using LLama.Common;

namespace GGUFReader.Services;

public class InferenceParamsService : IInferenceParamsService
{
    public ILlamaInferenceParams GetDefaultParams()
    {
        return new LlamaInferenceParams()
        {
            Temperature = 0.7f,
            MaxTokens = 100,
            Mirostat = MirostatType.Mirostat2,
            MirostatTau = 5.0f
        };
    }
}
