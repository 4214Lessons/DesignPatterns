namespace TemplateMethod;

// UML diaqramındakı AbstractClass (DataAnalyzerBase) sinfindən törənir.
// UML diaqramındakı ConcreteClass strukturuna uyğundur.
class HtmlDataAnalyzer : DataAnalyzerBase
{
    public override void ExportResult(object result)
    {
        // Vəziyyətin HTML-ə çevrilməsi prosesi yer alacaq.
        Console.WriteLine("HTML exported.");
    }
}