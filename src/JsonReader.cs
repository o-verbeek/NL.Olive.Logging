using System.Text;
using System.Text.Json;

namespace NL.Olive.Logging;

internal static class JsonReader
{
    internal static string ReadProperty(string fileName, string propertyName)
    {
        using var stream = new FileStream(fileName, FileMode.Open);

        byte[] jsonBytes = new byte[stream.Length];
        stream.Read(jsonBytes, 0, jsonBytes.Length);

        string jsonString = Encoding.UTF8.GetString(jsonBytes);
        JsonDocument document = JsonDocument.Parse(jsonString);

        var value = document.RootElement.GetProperty(propertyName);
        return value.ToString();
    }
}
