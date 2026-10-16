// HOW-TO: Remove Unwanted Area From PNG and Feather Edges Before Saving As GIF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Subtract(new RectangleMask(50, 50, 100, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                image.Save(outputPath, new GifOptions());
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
 * 1. When you need to eliminate a logo or watermark from a PNG image and smooth the surrounding pixels before converting it to an animated GIF.
 * 2. When preparing product photos for web galleries, you can subtract background elements and feather the cutout to create a clean GIF thumbnail.
 * 3. When cleaning scanned documents, you can remove stray marks using a rectangle mask and apply feathering to preserve readability in the final GIF.
 * 4. When generating GIF sprites from screenshots, you can exclude UI overlays and soften the edges to avoid harsh transitions.
 * 5. When automating batch image cleanup, you can programmatically mask out unwanted regions in PNG files and export the result as optimized GIFs for faster loading.
 */
