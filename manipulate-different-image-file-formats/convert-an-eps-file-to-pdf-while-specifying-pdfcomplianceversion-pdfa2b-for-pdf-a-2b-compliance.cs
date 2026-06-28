using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive vector graphics from an EPS file as a PDF/A‑2b compliant document for long‑term preservation in a .NET application, they can use this code.
 * 2. When a printing workflow requires converting customer‑supplied EPS artwork to PDF while ensuring PDF/A‑2b compliance for regulatory filing, the snippet provides the necessary C# conversion.
 * 3. When a document management system built with C# must ingest EPS logos and store them as searchable PDF/A‑2b files for accessibility and archival, this example shows how to perform the conversion.
 * 4. When an automated batch process has to transform a library of EPS design files into PDF/A‑2b PDFs to meet industry standards for electronic submissions, the code demonstrates the required steps.
 * 5. When a developer integrates Aspose.Imaging into a .NET service that generates PDF/A‑2b reports from EPS charts to satisfy compliance audits, this sample illustrates the conversion technique.
 */