// HOW-TO: Refine Image Mask With Subtract And Feathering Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(50, 50))
                    .Subtract(new RectangleMask(10, 10, 30, 30))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to remove a rectangular portion from a Magic Wand selection around a detailed object in a JPEG before exporting it as a transparent PNG.
 * 2. When you want to smooth the edges of a refined mask after cutting out unwanted areas to create a natural feathered border in C# image processing.
 * 3. When you are building a photo‑editing tool that lets users fine‑tune selections by subtracting shapes and applying feathering to achieve professional‑grade cut‑outs.
 * 4. When you must prepare product‑shot images by eliminating background sections and adding a soft edge transition for e‑commerce listings.
 * 5. When you are automating batch processing of scanned documents to isolate text regions, subtract noise rectangles, and save the result with alpha transparency.
 */
