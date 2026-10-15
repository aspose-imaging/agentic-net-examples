// HOW-TO: Batch Resize and Sharpen PNG Images to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                        image.CacheData();

                    image.Resize(640, 480, ResizeType.NearestNeighbourResample);
                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to convert a folder of high‑resolution PNG screenshots into uniformly sized PDF pages for documentation, this code automates the process.
 * 2. When preparing product catalog images, you can batch resize PNG photos to 640×480, sharpen them for clarity, and output a single PDF per image using C#.
 * 3. When generating printable PDFs from scanned PNG receipts, the routine ensures each page has the correct dimensions and enhanced readability.
 * 4. When building an automated report that embeds PNG charts, the code resizes and sharpens each chart before embedding it as a PDF for consistent layout.
 * 5. When migrating legacy PNG assets to a PDF archive, the script batch processes the files, applies a sharpening filter to improve visual quality, and stores them in a searchable PDF format.
 */
