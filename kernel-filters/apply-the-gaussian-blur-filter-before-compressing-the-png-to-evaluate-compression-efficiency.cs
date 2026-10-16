// HOW-TO: Apply Gaussian Blur to PNG and Save with Compression in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                var pngOptions = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel6,
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
            }

            FileInfo info = new FileInfo(outputPath);
            Console.WriteLine($"Compressed file size: {info.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce visual noise in a PNG before archiving it to achieve smaller file sizes.
 * 2. When generating thumbnails for a web gallery where a soft blur improves aesthetics while keeping the image compressed.
 * 3. When preprocessing medical or satellite images with Gaussian blur to smooth details prior to loss‑less PNG compression for storage.
 * 4. When automating a batch job that applies a blur filter to scanned documents and saves them as optimized PNG files for faster download.
 * 5. When evaluating how different image filters affect PNG compression efficiency in a C# performance test using Aspose.Imaging.
 */
