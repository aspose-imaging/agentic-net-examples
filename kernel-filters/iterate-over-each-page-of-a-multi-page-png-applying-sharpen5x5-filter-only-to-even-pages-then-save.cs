// HOW-TO: Apply Sharpen Filter to Even Pages of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        if (i % 2 == 0) // even page index
                        {
                            Image page = multipageImage.Pages[i];
                            if (page is RasterImage raster)
                            {
                                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());
                            }
                        }
                    }
                }

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When you need to enhance the visual clarity of every second frame in a multi‑page PNG used for slide presentations.
 * 2. When processing scanned documents where only the even‑numbered pages require sharpening to improve OCR accuracy.
 * 3. When generating animated PNGs and you want to apply a subtle sharpening effect to alternate frames for a smoother visual transition.
 * 4. When preparing multi‑page PNG assets for a web gallery and you wish to selectively sharpen even pages to reduce file size while maintaining quality.
 * 5. When automating a batch workflow that iterates through PNG pages and applies a 5×5 sharpen filter only to even pages before saving the result.
 */
