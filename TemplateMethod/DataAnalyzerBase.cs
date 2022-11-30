namespace TemplateMethod;

// Bu, bizim metod skeletimizi və mücərrəd metodlarımızı ehtiva edir.
// UML diaqramında AbstractClass strukturuna uyğundur.
abstract class DataAnalyzerBase
{
    // Bizim metodumuzun skeleti.
    public void AnalyzeDataOfLastWeek()
    {
        object data = GetDataOfLastWeek();
        object result = AnalyzeData(data);
        ExportResult(result);
    }

    private object GetDataOfLastWeek()
    {
        // Burada məlumat məlumatlarının çağırılması prosesləri olacaq.
        // Default olaraq, obyekt qaytarılır.
        Console.WriteLine("Method worked: GetDataOfLastWeek");
        return new object();
    }

    private object AnalyzeData(object data)
    {
        // Burda məlumatların təhlili prosesi.
        // Təhlil nəticələri default olaraq obyekti qaytarır.
        Console.WriteLine("Method worked: AnalyzeData");
        return new object();
    }

    // Bu, alt siniflər tərəfindən həyata keçirilməsini istədiyimiz metoddur.
    // Metod çərçivəsində fərqlənəcək bizim metodumuzdur.
    public abstract void ExportResult(object result);
}