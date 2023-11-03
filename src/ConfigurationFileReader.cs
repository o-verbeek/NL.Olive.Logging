namespace NL.Olive.Logging;

internal static class ConfigurationFileReader
{
    public static string GetProperty(string fileName, string keyName)
    {
        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentNullException(nameof(fileName));

        if (string.IsNullOrEmpty(keyName)) 
            throw new ArgumentNullException(nameof(keyName));

        return JsonReader.ReadProperty(fileName, keyName);
    }
}
