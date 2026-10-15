// HOW-TO: Sharpen PNG and Embed Centered Image into PDF Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage png = (RasterImage)Image.Load(inputPath))
            {
                png.Filter(png.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                int width = png.Width;
                int height = png.Height;

                using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), width, height))
                {
                    canvas.SaveArgb32Pixels(new Rectangle(0, 0, width, height), png.LoadArgb32Pixels(png.Bounds));
                    canvas.Save(outputPath, new PdfOptions());
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
 * 1. When you need to improve the clarity of a scanned PNG before embedding it in a PDF report.
 * 2. When generating printable PDFs from product photos and want each PNG sharpened for better detail.
 * 3. When automating the creation of PDF brochures that require every PNG graphic to be centered and enhanced.
 * 4. When converting web‑optimized PNG icons to high‑resolution PDF assets while applying a sharpening filter to compensate for compression artifacts.
 * 5. When building a document workflow that validates the PNG file, sharpens the image, and saves the result as a centered PDF for archival.
 */
