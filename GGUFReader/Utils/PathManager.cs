using System.Reflection;

namespace GGUFReader.Utils;

public static class PathManager
{
    private static readonly string EXCEPTION_MESSAGE = "Main Path cannot be retrieved";

    private static Func<string?> _getEntryAssemblyLocation = () => Assembly.GetEntryAssembly()?.Location;

    public static string MainPath => Path.GetDirectoryName(_getEntryAssemblyLocation())
        ?? throw new Exception(EXCEPTION_MESSAGE);

    public static string GetModelPath(string folderPath, string modelName)
    {
        return Path.Combine(MainPath, folderPath, modelName);
    }

    public static void SetEntryAssemblyLocationFunc(Func<string?> getEntryAssemblyLocation)
    {
        _getEntryAssemblyLocation = getEntryAssemblyLocation;
    }
}
