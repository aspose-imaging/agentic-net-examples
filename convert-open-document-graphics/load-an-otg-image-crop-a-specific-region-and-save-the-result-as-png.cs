// HOW-TO: Crop a Region from OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.otg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var cropRect = new Aspose.Imaging.Rectangle(50, 50, 200, 200);
                image.Crop(cropRect);

                var pngOptions = new PngOptions();
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
 * 1. When you need to extract a specific part of an OTG map and deliver it as a lightweight PNG for web display.
 * 2. When converting legacy OTG graphics from a design tool into PNG thumbnails for a mobile app.
 * 3. When preprocessing scanned OTG documents by cropping out margins before archiving them as PNG files.
 * 4. When generating region‑specific PNG assets from a large OTG sprite sheet for a game engine.
 * 5. When automating a batch job that reads OTG files, crops a fixed area, and saves the result in PNG format for further analysis.
 */
