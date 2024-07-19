using GGUFReader.Models;
using LLama;
using LLama.Abstractions;
using LLama.Common;

namespace GGUFReader.Factories;

public class LLamaModelExecutorFactory : ILLamaModelExecutorFactory
{
    public class NullPathException(string? path) : ArgumentException("Path cannot be null or empty", nameof(path)) { }
    
    public ILLamaExecutor CreateExecutor(LLamaExecutorConfiguration config)
    {
        if (string.IsNullOrWhiteSpace(config.Path))
        {
            throw new NullPathException(nameof(config.Path));
        }

        ModelParams modelParams = new(config.Path);
        LLamaWeights weights = LLamaWeights.LoadFromFile(modelParams);
        LLamaContext context = weights.CreateContext(modelParams);

        return new InteractiveExecutor(context);
    }
}
