// HOW-TO: Convert OTG to PDF with 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.otg";
        string outputPath = "Output\\sample.pdf";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
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
 * 1. When you need to generate high‑resolution printable PDFs from OTG vector graphics in a .NET application.
 * 2. When an automated document pipeline must convert archived OTG files to PDF while preserving 300 dpi quality for compliance.
 * 3. When a reporting tool requires embedding OTG diagrams into PDF reports with consistent DPI settings.
 * 4. When a web service receives OTG uploads and must return PDF versions optimized for screen and print rendering.
 * 5. When migrating legacy design assets stored as OTG into PDF format for integration with modern document management systems.
 */
