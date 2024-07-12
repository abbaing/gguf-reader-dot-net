using System.Reflection;

namespace GGUFReader.Utils;

public static class PathManager
{
    private static readonly string EXCEPTION_MESSAGE = "Main Path cannot be retrieved";

    public static readonly string MainPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)
        ?? throw new Exception(EXCEPTION_MESSAGE);

    public static string GetModelPath(string modelPath, string folderPath, string modelName)
    {
        return Path.Combine(MainPath, modelPath, folderPath, modelName);
    }
}
