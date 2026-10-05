// HOW-TO: Render TIFF To PDF With Anti-Alias Smoothing In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing.Drawing2D;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.tiff";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using var image = Image.Load(inputPath);
            var pdfOptions = new PdfOptions();
            var vectorOptions = new VectorRasterizationOptions
            {
                SmoothingMode = SmoothingMode.AntiAlias
            };
            pdfOptions.VectorRasterizationOptions = vectorOptions;
            image.Save(outputPath, pdfOptions);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert high‑resolution scanned TIFF documents to PDF while preserving smooth vector edges for professional printing.
 * 2. When generating PDF reports from multi‑page TIFF files and want anti‑aliased graphics to improve on‑screen readability.
 * 3. When creating searchable PDFs from TIFF images in a document management system and require crisp line art without jagged artifacts.
 * 4. When automating batch conversion of TIFF graphics to PDF in a C# application and need consistent smoothing across all pages.
 * 5. When integrating Aspose.Imaging into a workflow that archives medical imaging TIFFs as PDFs and must maintain visual quality for diagnostic review.
 */
