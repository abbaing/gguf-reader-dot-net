using LLama.Common;

namespace GGUFReader.Services;

public class GGUFServiceParams(
    int maxTokens,
    MirostatType mirostat,
    float mirostatTau,
    float temperature = 0.7f)
{
    public float Temperature { get; set; } = temperature;

    public int MaxTokens { get; set; } = maxTokens;
    public MirostatType Mirostat { get; set; } = mirostat;
    public float MirostatTau { get; set; } = mirostatTau;
}