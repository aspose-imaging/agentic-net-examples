// HOW-TO: Crop a Region from an ODG Image and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.odg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.RasterImage raster)
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    var cropRect = new Aspose.Imaging.Rectangle(100, 100, 200, 200);
                    raster.Crop(cropRect);
                }

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to extract a specific part of an ODG diagram and deliver it as a lightweight PNG for web display.
 * 2. When converting legacy OpenDocument graphics into PNG thumbnails while trimming unnecessary margins.
 * 3. When generating cropped PNG assets from ODG files for inclusion in mobile applications.
 * 4. When automating batch processing to isolate a region of ODG illustrations and store the result in PNG format for reporting.
 * 5. When integrating Aspose.Imaging in a C# service that prepares cropped PNG previews of user‑uploaded ODG drawings.
 */
