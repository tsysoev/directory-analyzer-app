using System;
using System.IO;

namespace DirectoryAnalyzer;

public class DirectoryWatcher
{
    private readonly FileAnalyzer _fileAnalyzer = new();

    public void Watch(string directory)
    {
        using var watcher = new FileSystemWatcher(directory);
        watcher.Filter = "*.*";
        watcher.IncludeSubdirectories = false;
        watcher.EnableRaisingEvents = true;
        watcher.Created += OnCreated;

        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Created: {e.FullPath}");
        var file = new FileInfo(e.FullPath);
        _fileAnalyzer.Analyze(file);
    }
}