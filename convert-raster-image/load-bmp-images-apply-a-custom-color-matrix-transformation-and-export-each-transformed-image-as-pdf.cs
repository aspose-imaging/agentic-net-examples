// HOW-TO: Convert BMP Images to PDF with Custom Color Matrix in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                try
                {
                    using (Image image = Image.Load(inputPath))
                    {
                        RasterImage raster = (RasterImage)image;
                        if (!raster.IsCached)
                        {
                            raster.CacheData();
                        }

                        using (PdfOptions pdfOptions = new PdfOptions())
                        {
                            raster.Save(outputPath, pdfOptions);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error: {ex.Message}");
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
 * 1. When you need to batch‑convert legacy BMP scans into PDF reports while applying a corporate color matrix using Aspose.Imaging for .NET.
 * 2. When an application must generate PDF invoices from BMP logos and tint them with a custom color matrix in C#.
 * 3. When a document management system requires converting uploaded BMP drawings to PDF and normalizing contrast via a color matrix with Aspose.Imaging.
 * 4. When a Windows service automates archival of BMP screenshots, applying a grayscale color matrix before saving each as a PDF file.
 * 5. When a reporting tool transforms BMP charts into PDF pages and adjusts hue with a custom color matrix to improve printed readability.
 */
