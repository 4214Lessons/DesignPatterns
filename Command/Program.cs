using ClosedXML.Excel;
using System.Data;
using System.IO.Compression;


namespace CommandPattern;


#nullable disable
// Nuget: ClosedXML




public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}








// Receiver
public class ExcelFile<T>
{
    private readonly List<T> _list;
    public string FileName => $"{typeof(T).Name}.xlsx";


    public ExcelFile(List<T> list)
    {
        _list = list;
    }

    public MemoryStream Create()
    {
        var wb = new XLWorkbook();
        var ds = new DataSet();

        ds.Tables.Add(GetTable());

        wb.Worksheets.Add(ds);

        var excelMemory = new MemoryStream();
        wb.SaveAs(excelMemory);

        return excelMemory;
    }

    private DataTable GetTable()
    {
        var table = new DataTable();

        var type = typeof(T); // Product

        type.GetProperties()
            .ToList()
            .ForEach(x => table.Columns.Add(x.Name, x.PropertyType));


        _list.ForEach(x =>
        {
            var values = type.GetProperties()
                                .Select(properyInfo => properyInfo
                                .GetValue(x, null))
                                .ToArray();

            table.Rows.Add(values);
        });

        return table;
    }
}







// Homework: Receiver
public class PdfFile<T>
{
    private readonly List<T> _list;
    public string FileName => $"{typeof(T).Name}.pdf";


    public PdfFile(List<T> list)
    {
        _list = list;
    }




    public MemoryStream Create()
    {
        throw new NotImplementedException();
    }
}









public interface ITableActionCommand
{
    void Execute();
}



public class CreateExcelTableActionCommand<T> : ITableActionCommand
{
    private readonly ExcelFile<T> _excelFile;

    public CreateExcelTableActionCommand(ExcelFile<T> excelFile)
        => _excelFile = excelFile;


    public void Execute()
    {
        MemoryStream excelMemoryStream = _excelFile.Create();
        File.WriteAllBytes(_excelFile.FileName, excelMemoryStream.ToArray());
    }
}




//// Homework
public class CreatePdfTableActionCommand<T> : ITableActionCommand
{
    private readonly PdfFile<T> _pdfFile;

    public CreatePdfTableActionCommand(PdfFile<T> pdfFile)
      => _pdfFile = pdfFile;


    public void Execute()
    {
        throw new NotImplementedException();
    }
}












// Invoker
class FileCreateInvoker
{
    private ITableActionCommand _tableActionCommand;
    private List<ITableActionCommand> _tableActionCommands = new();

    public void SetCommand(ITableActionCommand tableActionCommand)
    {
        _tableActionCommand = tableActionCommand;
    }


    public void AddCommand(ITableActionCommand tableActionCommand)
    {
        _tableActionCommands.Add(tableActionCommand);
    }

    public void CreateFile()
    {
        _tableActionCommand.Execute();
    }

    public void CreateFiles()
    {
        _tableActionCommands.ForEach(cmd => cmd.Execute());

        // ZipArchive
    }

}
















class Program
{
    static void Main()
    {

        List<Product> products = Enumerable.Range(1, 30).Select(index =>
            new Product
            {
                Id = index,
                Name = $"Product {index}",
                Price = index + 100,
                Stock = index
            }
        ).ToList();





        ExcelFile<Product> receiverExcel = new(products);
        PdfFile<Product> receiverPdf = new(products);



       FileCreateInvoker invoker = new();
       invoker.AddCommand(new CreateExcelTableActionCommand<Product>(receiverExcel));
       invoker.AddCommand(new CreatePdfTableActionCommand<Product>(receiverPdf));
       invoker.CreateFiles();
    }
}