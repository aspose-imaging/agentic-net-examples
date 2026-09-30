// HOW-TO: How to Convert PNG to PDF with Error Handling in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.pdf";

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
 * 1. When an application needs to batch‑convert user‑uploaded PNG images to PDF reports while safely handling missing files and logging any conversion errors.
 * 2. When a server‑side service generates PDF invoices from PNG logos and must ensure the output directory exists and capture exceptions for troubleshooting.
 * 3. When a desktop utility transforms scanned PNG pictures into searchable PDF documents and requires graceful error messages if the conversion fails.
 * 4. When an automated workflow saves PNG thumbnails as PDF previews and needs to log failures without crashing the entire process.
 * 5. When a cloud function processes PNG assets into PDF format and must validate input paths, create target folders, and record any exceptions for monitoring.
 */
