// HOW-TO: Convert DjVu to Scaled TIFF with Proportional Resize in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.djvu";
        string tempPath = "temp/output.tif";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                djvu.Save(tempPath, tiffOptions);
            }

            using (RasterImage tiffImage = (RasterImage)Image.Load(tempPath))
            {
                double scale = 0.5;
                int newWidth = (int)(tiffImage.Width * scale);
                int newHeight = (int)(tiffImage.Height * scale);
                tiffImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                tiffImage.Save(outputPath);
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
 * 1. When you need to archive scanned documents originally in DjVu format as smaller TIFF files for compatibility with legacy systems.
 * 2. When you want to generate thumbnail previews of DjVu pages by converting them to TIFF and reducing their dimensions by half.
 * 3. When a workflow requires converting multi‑page DjVu files to single‑page TIFF images before applying further image processing.
 * 4. When you must integrate DjVu content into a .NET application that only supports TIFF, while also optimizing file size through proportional scaling.
 * 5. When you are preparing DjVu‑based e‑books for printing and need to resize the pages to fit a specific DPI using C#.
 */
