// HOW-TO: Convert DjVu Pages To Scaled TIFF Images In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPattern = "output/page_{0}.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    var page = djvu.Pages[i];
                    int width = page.Width;
                    int height = page.Height;

                    // Determine scaling factor (max dimension 1000)
                    const int targetMax = 1000;
                    double scale = Math.Min(1.0, (double)targetMax / Math.Max(width, height));
                    int newWidth = (int)(width * scale);
                    int newHeight = (int)(height * scale);

                    string outputPath = string.Format(outputPattern, i);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Export the specific page to TIFF
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateBw);
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(i);
                    djvu.Save(outputPath, tiffOptions);

                    // Resize if scaling is needed
                    if (scale < 1.0)
                    {
                        using (RasterImage tif = (RasterImage)Image.Load(outputPath))
                        {
                            tif.Resize(newWidth, newHeight);
                            tif.Save(outputPath);
                        }
                    }

                    Console.WriteLine($"Page {i + 1}/{pageCount}: Original ({width}x{height}), Saved {(scale < 1.0 ? $"scaled to ({newWidth}x{newHeight})" : "original size")} at {outputPath}");
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
 * 1. When you need to extract each page of a multi‑page DjVu document and save them as separate TIFF files for archival or printing.
 * 2. When the original DjVu pages are larger than a desired maximum size and you must automatically downscale them to fit within a 1000‑pixel limit before conversion.
 * 3. When a workflow requires knowing the exact width and height of each DjVu page to calculate custom scaling or layout decisions.
 * 4. When you want to programmatically create multi‑page TIFF files from specific DjVu pages while preserving compression settings.
 * 5. When integrating document processing in a C# application that must handle DjVu input, resize images, and output TIFFs for downstream systems such as OCR or document management.
 */
