using System;
using System.Xml;

namespace DirectoryAnalyzer.AnalysisOperations;

public class DivTagsCountOperation : IAnalysisOperation
{
    public string Operation => "DivTagsCount";

    public string Process(string text)
    {
        try
        {
            var doc = new XmlDocument();
            doc.LoadXml(text);
            int? count = doc.SelectNodes("//div")?.Count;
            return count.ToString() ?? "0";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}