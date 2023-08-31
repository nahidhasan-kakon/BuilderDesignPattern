

// product: report class
public class Report
{
    public string ReportTitle { get; set; }
    public string ReportDescription { get; set; } 
    public string ReportType { get; set; }
    public string ReportContent { get; set; }

    public override string ToString()
    {
        return $"Report title: {ReportTitle},Description: {ReportDescription},Type: {ReportType}, Content: {ReportContent}";
    }
}

// builder: abstract class
public abstract class ReportBuilder
{
    protected Report report;
    public abstract void SetReportTitle();
    public abstract void SetReportDescription();
    public abstract void SetReportType();
    public abstract void SetReportContent();

    public void CreateNewReport()
    {
        report = new Report();
    }

    public Report GetReport() { return report; }
}

// concrete builder: excel report class
public class ExcelReport : ReportBuilder
{
    public override void SetReportContent()
    {
       report.ReportContent = "Excel Content";
    }

    public override void SetReportDescription()
    {
        report.ReportDescription = "This is a short description of excel report";
    }

    public override void SetReportTitle()
    {
        report.ReportTitle = "Excel template";
    }

    public override void SetReportType()
    {
        report.ReportType = "excel";
    }
}

// director: Report director class
public class ReportDirector
{
    private ReportBuilder _reportBuilder;
    public ReportDirector(ReportBuilder reportBuilder) 
    { 
        _reportBuilder = reportBuilder;
    }

    public void MakeReport()
    {
        _reportBuilder.CreateNewReport();
        _reportBuilder.SetReportTitle();
        _reportBuilder.SetReportDescription();
        _reportBuilder.SetReportType();
        _reportBuilder.SetReportContent();
    }

    public void GetReport()
    {
        Console.WriteLine(_reportBuilder.GetReport());
    }
}

public class Program
{
    static void Main(string[] args)
    {
        ReportBuilder excelReport = new ExcelReport();
        ReportDirector reportDirector = new ReportDirector(excelReport);
        reportDirector.MakeReport();
        reportDirector.GetReport();
    }
}