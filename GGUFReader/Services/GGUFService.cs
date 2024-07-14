using GGUFReader.Utils;
using LLama.Abstractions;
using LLama.Common;

namespace GGUFReader.Services;
public class GGUFService(ILLamaExecutor executor, GGUFServiceParams serviceParams)
{
    public async Task<string> GenerateResponse(string prompt)
    {
        InferenceParams inferenceParams = new()
        {
            Temperature = serviceParams.Temperature,
            MaxTokens = serviceParams.MaxTokens,
            Mirostat = serviceParams.Mirostat,
            MirostatTau = serviceParams.MirostatTau,
        };

        return await StringManager.AsyncAppend(executor.InferAsync(prompt, inferenceParams));
    }
}
