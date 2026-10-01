// HOW-TO: Convert ODG To PDF With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to programmatically transform OpenDocument graphics (ODG) files into PDF documents for cross‑platform viewing in a .NET application.
 * 2. When you want to generate PDF reports from ODG diagrams created in LibreOffice using Aspose.Imaging without manual export.
 * 3. When an automated workflow must convert user‑uploaded ODG illustrations to PDF for archiving or printing on a server.
 * 4. When you are building a document conversion service that accepts ODG files and returns PDF files while preserving vector quality in C#.
 * 5. When you need to batch‑process a folder of ODG assets into PDFs as part of a content‑management pipeline in a Windows environment.
 */
