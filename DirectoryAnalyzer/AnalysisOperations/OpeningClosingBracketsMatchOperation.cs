using System.Collections.Generic;

namespace DirectoryAnalyzer.AnalysisOperations;

public class OpeningClosingBracketsMatchOperation : IAnalysisOperation
{
    public string Operation => "OpeningClosingBracketsMatch";

    public string Process(string text) => 
        CheckBrackets(text).ToString();

    private bool CheckBrackets(string text)
    {
        var (openBracket, closeBracket) = ('{', '}');
        var stack = new Stack<char>();

        foreach (char symbol in text)
        {
            if (symbol == openBracket)
                stack.Push(symbol);
            else if (symbol == closeBracket)
            {
                if (stack.Count == 0)
                    return false;

                stack.Pop();
            }
        }

        return stack.Count == 0;
    }
}