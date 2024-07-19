using GGUFReader.Models;

namespace GGUFReader.Services;

public interface IInferenceParamsService
{
    ILlamaInferenceParams GetDefaultParams();
}
