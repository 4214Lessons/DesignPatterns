namespace TemplateMethod;

class Program
{
    static void Main()
    {
        DataAnalyzerBase dataAnalyzer;


        dataAnalyzer = new XmlDataAnalyzer();
        dataAnalyzer.AnalyzeDataOfLastWeek();
        
        
        // OUTPUT:
        //  Method worked: GetDataOfLastWeek
        //  Method worked: AnalyzeData
        //  XML exported.

        dataAnalyzer = new HtmlDataAnalyzer();
        dataAnalyzer.AnalyzeDataOfLastWeek();

        // OUTPUT:
        //  Method worked: GetDataOfLastWeek
        //  Method worked: AnalyzeData
        //  HTML exported.
    }
}