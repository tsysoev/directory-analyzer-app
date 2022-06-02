using System.Collections.Generic;
using DirectoryAnalyzer.AnalysisOperations;

namespace DirectoryAnalyzer;

public class TextAnalyzer
{
    private static readonly Dictionary<string, IAnalysisOperation> DefaultAnalysisOperations = new()
    {
        [".html"] = new DivTagsCountOperation(),
        [".css"] = new OpeningClosingBracketsMatchOperation(),
        ["default"] = new PunctuationMarksCountOperation(),
    };

    private IAnalysisOperation _analysisOperation;

    public TextAnalyzer(string fileExtension)
    {
        _analysisOperation = DefaultAnalysisOperations.ContainsKey(fileExtension) 
            ? DefaultAnalysisOperations[fileExtension] 
            : DefaultAnalysisOperations["default"];
    }

    public string OperationName => 
        _analysisOperation.Operation;

    public string Analyze(string text) => 
        _analysisOperation.Process(text);

    public string Analyze(string text, IAnalysisOperation operation)
    {
        _analysisOperation = operation;
        return _analysisOperation.Process(text);
    }
}