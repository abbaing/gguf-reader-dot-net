using GGUFReader.Models;
using LLama.Abstractions;

namespace GGUFReader.Factories;

public interface ILLamaModelExecutorFactory
{
    ILLamaExecutor CreateExecutor(LLamaExecutorConfiguration config);
}
