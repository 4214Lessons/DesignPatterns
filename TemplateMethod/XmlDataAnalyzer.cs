namespace TemplateMethod;

// UML diaqramındakı AbstractClass (DataAnalyzerBase) sinfindən törənir.
// UML diaqramındakı ConcreteClass strukturuna uyğundur.
class XmlDataAnalyzer : DataAnalyzerBase
{
    public override void ExportResult(object result)
    {
        // Vəziyyətin XML-ə çevrilməsi prosesi yer alacaq.
        Console.WriteLine("XML exported.");
    }
}