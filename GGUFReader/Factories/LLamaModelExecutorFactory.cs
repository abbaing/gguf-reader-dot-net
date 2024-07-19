using GGUFReader.Models;
using LLama;
using LLama.Abstractions;
using LLama.Common;

namespace GGUFReader.Factories;

public class LLamaModelExecutorFactory : ILLamaModelExecutorFactory
{
    public class NullPathException(string? path) : ArgumentException("Path cannot be null or empty", nameof(path)) { }
    public class NullModelNameException(string? modelName) : ArgumentException("Path cannot be null or empty", nameof(modelName)) { }

    public ILLamaExecutor CreateExecutor(LLamaExecutorConfiguration config)
    {
        if (string.IsNullOrWhiteSpace(config.Path))
        {
            throw new NullPathException(nameof(config.Path));
        }

        if (string.IsNullOrWhiteSpace(config.ModelName))
        {
            throw new NullModelNameException(nameof(config.ModelName));
        }

        string modelPath = Path.Combine(config.Path, config.ModelName);

        ModelParams modelParams = new(modelPath);
        LLamaWeights weights = LLamaWeights.LoadFromFile(modelParams);
        LLamaContext context = weights.CreateContext(modelParams);

        return new InteractiveExecutor(context);
    }
}
