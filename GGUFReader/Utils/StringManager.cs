using System.Text;

namespace GGUFReader.Utils;

public class StringManager
{
    public static async Task<string> AsyncAppend(IAsyncEnumerable<string> strings)
    {
        StringBuilder builder = new();
        await foreach (string toAppend in strings)
        {
            _ = builder.Append(toAppend);
        }
        return builder.ToString();
    }
}
