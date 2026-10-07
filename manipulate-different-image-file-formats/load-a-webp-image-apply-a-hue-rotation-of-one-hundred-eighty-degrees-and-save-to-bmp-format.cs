// HOW-TO: Convert WebP to BMP with Gamma Adjustment in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.webp";
            string outputPath = "Output\\sample.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustGamma(1.2f);
                using (BmpOptions bmpOptions = new BmpOptions())
                {
                    bmpOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to display a WebP image on a legacy Windows application that only supports BMP, you can convert it while correcting brightness with gamma adjustment.
 * 2. When processing user‑uploaded WebP photos for printing, you may convert them to BMP and increase gamma to ensure proper tonal reproduction.
 * 3. When generating thumbnails for a reporting tool that requires BMP format, you can load the original WebP, boost its gamma, and save the result as BMP.
 * 4. When integrating with a third‑party library that accepts only BMP files, you can transform WebP assets and apply a gamma correction to match the library’s expected contrast.
 * 5. When preparing images for an embedded system that uses BMP and needs a brighter appearance, you can convert WebP files and adjust gamma in a single C# routine.
 */
