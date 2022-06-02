using System.Linq;

namespace DirectoryAnalyzer.AnalysisOperations;

public class PunctuationMarksCountOperation : IAnalysisOperation
{
    public string Operation => "PunctuationMarksCount";

    public string Process(string text) => 
        text.Count(char.IsPunctuation).ToString();
}