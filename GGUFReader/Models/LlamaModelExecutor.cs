using LLama;
using Microsoft.Extensions.Logging;

namespace GGUFReader.Models
{
    public class LlamaModelExecutor(LLamaContext context, ILogger? logger = null) : 
        InteractiveExecutor(context, logger), ILLamaModelExecutor
    {
    }
}
