using GGUFReader.Models;

namespace GGUFReader.Factories;

public interface ILLamaModelExecutorFactory
{
    ILLamaModelExecutor CreateExecutor(LLamaExecutorConfiguration config);
}
