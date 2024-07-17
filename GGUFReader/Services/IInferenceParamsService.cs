using LLama.Abstractions;

namespace GGUFReader.Services;

public interface IInferenceParamsService
{
    IInferenceParams GetDefaultParams();
}
