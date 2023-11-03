namespace NL.Olive.Logging;

internal class FileWatcher : IDisposable
{
    private readonly FileSystemWatcher _fileWatcher;
    private readonly string _fileName;

    public FileWatcher(string fileName)
    {
        this._fileName = fileName;
        this._fileWatcher = new FileSystemWatcher();

        this.InitializeFileWatcher();
    }

    protected void InitializeFileWatcher()
    {
        var directory = Path.GetDirectoryName(this._fileName);
        var path = string.IsNullOrEmpty(directory) ? Directory.GetCurrentDirectory() : directory;

        this._fileWatcher.Path = path;
        this._fileWatcher.Filter = this._fileName;
        this._fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
        this._fileWatcher.EnableRaisingEvents = true;
        this._fileWatcher.Changed += this.OnChanged;
    }

    public void Dispose()
    {
        this._fileWatcher.Changed -= this.OnChanged;
        this._fileWatcher.Dispose();
    }

    public void OnChanged(object? sender, FileSystemEventArgs args)
    {
        this.FileChanged?.Invoke(this, args);
    }

    public event EventHandler<FileSystemEventArgs>? FileChanged;
}
