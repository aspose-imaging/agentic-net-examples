// HOW-TO: Create 200x200 BMP Thumbnail PDF with Median Filter in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/thumbnail.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                image.Resize(200, 200);
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a small PDF preview of a large BMP image while reducing noise with a median filter.
 * 2. When an application must create 200 × 200 pixel thumbnails from scanned BMP documents for quick display in a web portal.
 * 3. When you want to convert legacy BMP graphics into PDF format for archiving, applying a median filter to improve visual quality.
 * 4. When a reporting tool requires uniform PDF thumbnails of various BMP assets, ensuring consistent size and noise reduction.
 * 5. When automating batch processing of BMP files to produce PDF thumbnails for email attachments, using Aspose.Imaging in C#.
 */
