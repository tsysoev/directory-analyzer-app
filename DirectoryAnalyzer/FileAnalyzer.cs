using System.IO;
using System.Threading.Tasks;

namespace DirectoryAnalyzer;

public class FileAnalyzer
{
    private readonly FileInfo _resultFile = new("analyze_result.txt");

    public void Analyze(FileInfo file)
    {
        string text = ReadText(file);
        var textAnalyzer = new TextAnalyzer(file.Extension);
        
        string result = textAnalyzer.Analyze(text);
        SaveResult(file.Name, textAnalyzer.OperationName, result);
    }

    private string ReadText(FileInfo file)
    {
        const int numberOfRetries = 3;
        const int delayOnRetry = 500;
        var exception = new IOException("Something went wrong, the file could not be read");

        for (int i = 0; i < numberOfRetries; i++)
        {
            try
            {
                using StreamReader reader = file.OpenText();
                string text = reader.ReadToEnd();
                reader.Close();
                return text;
            }
            catch (IOException ex)
            {
                exception = ex;
                Task.Delay(delayOnRetry);
            }
        }

        throw exception;
    }

    private void SaveResult(string fileName, string operation, string result)
    {
        using StreamWriter writer = _resultFile.AppendText();
        writer.WriteLine($"{fileName}-{operation}-{result}");
        writer.Close();
    }
}