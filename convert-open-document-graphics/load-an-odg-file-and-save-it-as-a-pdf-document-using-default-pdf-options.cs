// HOW-TO: Convert ODG to PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
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
 * 1. When you need to archive OpenDocument graphics (ODG) drawings as universally viewable PDF files in a .NET application.
 * 2. When generating printable reports that include ODG illustrations and must be saved as PDFs for distribution.
 * 3. When a workflow requires converting user‑uploaded ODG files to PDF before sending them to a third‑party API.
 * 4. When automating batch processing of design assets, converting each ODG file to a PDF for easy preview on any device.
 * 5. When integrating Aspose.Imaging into a C# service that transforms ODG diagrams into PDF documents for compliance documentation.
 */
