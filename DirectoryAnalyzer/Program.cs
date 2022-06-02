using System.IO;
using DirectoryAnalyzer;

var directory = new DirectoryInfo(@"./ObservedDirectory");
var directoryWatcher = new DirectoryWatcher();

directoryWatcher.Watch(directory.FullName);