using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

var salesFiles = FindFiles("stores");

foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

string reportPath = Path.Combine("stores", "sales-summary.txt");
GenerateSalesSummaryReport(salesFiles, reportPath);

Console.WriteLine();
Console.WriteLine($"Report written to: {reportPath}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

/// <summary>
/// Builds a sales summary from each sales.json file and saves it to disk.
/// </summary>
void GenerateSalesSummaryReport(IEnumerable<string> salesJsonFilePaths, string outputFilePath)
{
    var report = new StringBuilder();
    var details = new List<(string FilePath, decimal Total)>();
    decimal grandTotal = 0m;

    foreach (string path in salesJsonFilePaths)
    {
        string json = File.ReadAllText(path);
        SalesData? data = JsonSerializer.Deserialize<SalesData>(json);

        if (data is null)
            throw new InvalidDataException($"Could not read sales total from: {path}");

        details.Add((path, data.Total));
        grandTotal += data.Total;
    }

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($" Total Sales: {grandTotal:C}");
    report.AppendLine();
    report.AppendLine(" Details:");

    foreach (var (filePath, total) in details)
        report.AppendLine($"  {filePath}: {total:C}");

    File.WriteAllText(outputFilePath, report.ToString());
}

class SalesData
{
    public decimal Total { get; set; }
}
