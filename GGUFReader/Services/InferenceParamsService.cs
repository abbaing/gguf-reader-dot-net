using LLama.Abstractions;
using LLama.Common;

namespace GGUFReader.Services;

internal class InferenceParamsService : IInferenceParamsService
{
    public IInferenceParams GetDefaultParams()
    {
        return new InferenceParams()
        {
            Temperature = 0.7f,
            MaxTokens = 100,
            Mirostat = MirostatType.Mirostat2,
            MirostatTau = 5.0f
        };
    }
}
