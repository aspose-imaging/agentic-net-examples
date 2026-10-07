// HOW-TO: Convert JPEG to High-Resolution PDF with Custom DPI in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions options = new PdfOptions();
                options.ResolutionSettings = new ResolutionSetting(300, 300);
                image.Save(outputPath, options);
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
 * 1. When you need to generate a printable PDF from a JPEG image with 300 DPI to ensure sharpness for marketing brochures.
 * 2. When an application must batch‑convert user‑uploaded photos to high‑resolution PDFs for archival in a document management system.
 * 3. When a web service creates PDF invoices that embed product photos and requires a specific DPI to meet regulatory printing standards.
 * 4. When a desktop utility prepares images for large‑format printing by increasing the PDF output resolution before saving.
 * 5. When a reporting tool exports chart screenshots as PDFs and must control the DPI to maintain visual fidelity on high‑density displays.
 */
