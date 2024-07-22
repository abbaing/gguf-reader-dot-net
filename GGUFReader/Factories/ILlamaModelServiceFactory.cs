using GGUFReader.Services;

namespace GGUFReader.Factories;

public interface ILlamaModelServiceFactory
{
    ILlamaModelService Create(string folderPath, string modelName);
}
