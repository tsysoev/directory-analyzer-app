namespace DirectoryAnalyzer.AnalysisOperations;

public interface IAnalysisOperation
{
    public string Operation { get; }
    public string Process(string text);
}