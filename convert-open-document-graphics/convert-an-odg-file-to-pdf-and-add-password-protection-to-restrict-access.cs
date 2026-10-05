// HOW-TO: Convert ODG to PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
 * 1. When a developer needs to programmatically convert LibreOffice Draw (.odg) diagrams into PDF files for easy sharing or printing.
 * 2. When an application must batch‑process ODG assets and generate PDF reports without manual export.
 * 3. When a web service receives ODG uploads and must return a PDF version for client browsers that only support PDF viewing.
 * 4. When integrating document workflows that require converting vector graphics from ODG to PDF to embed them in larger PDF portfolios.
 * 5. When automating archival of design files by converting ODG drawings to PDF to ensure long‑term, platform‑independent storage.
 */
