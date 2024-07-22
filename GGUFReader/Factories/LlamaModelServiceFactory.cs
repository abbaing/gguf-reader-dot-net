using GGUFReader.Services;

namespace GGUFReader.Factories;

public class LlamaModelServiceFactory(IServiceProvider serviceProvider) : ILlamaModelServiceFactory
{
    public ILlamaModelService Create(string folderPath, string modelName)
    {
        return new LlamaModelService(folderPath, modelName, serviceProvider);
    }
}
