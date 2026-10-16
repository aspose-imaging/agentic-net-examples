// HOW-TO: Batch Sharpen Multiple Raster Images and Save as PDFs in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

            string[] allFiles = Directory.GetFiles(inputDirectory, "*.*");
            string[] rasterExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".tif", ".tiff", ".gif" };
            List<string> rasterFiles = allFiles
                .Where(f => rasterExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                .ToList();

            foreach (string inputPath in rasterFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                    var rect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);
                    raster.Filter(rect, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var pdfOptions = new PdfOptions())
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
 * 1. When you need to improve the visual clarity of a large set of scanned photos before archiving them as searchable PDF documents.
 * 2. When an e‑commerce platform must automatically enhance product pictures and generate PDF catalogs for offline distribution.
 * 3. When a medical imaging system requires batch sharpening of radiology scans and conversion to PDF for secure patient records.
 * 4. When a publishing workflow needs to apply a sharpening filter to multiple artwork files and bundle each into a separate PDF for proofing.
 * 5. When a document management solution must process mixed raster formats, enhance details, and store the results as PDF files for compliance reporting.
 */
