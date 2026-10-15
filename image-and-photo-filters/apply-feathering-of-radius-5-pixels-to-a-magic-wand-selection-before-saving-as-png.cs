// HOW-TO: Apply Feathered Magic Wand Selection and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\source.png";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
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
 * 1. When you need to smooth the edges of a region selected by the Magic Wand tool before exporting it as a transparent PNG in a C# application.
 * 2. When creating thumbnails that require a soft‑bordered cut‑out of an object, using feathered selection to avoid harsh edges.
 * 3. When preparing product photos for e‑commerce sites, applying a 5‑pixel feather to isolate the item and save it with an alpha channel in PNG format.
 * 4. When automating batch processing of scanned graphics where the Magic Wand selects background areas and feathering prevents visible seams after saving.
 * 5. When building a desktop image editor that lets users click to select an area and automatically applies a subtle feather before saving the result as a high‑quality PNG.
 */
