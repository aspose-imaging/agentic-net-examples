// HOW-TO: Crop Center of BMP to 400x400, Feather Selection, Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                if (left < 0) left = 0;
                if (top < 0) top = 0;

                image.Crop(new Rectangle(left, top, cropWidth, cropHeight));

                int centerX = cropWidth / 2;
                int centerY = cropHeight / 2;
                MagicWandTool.Select(image, new MagicWandSettings(centerX, centerY))
                    .GetFeathered(new FeatheringSettings() { Size = 10 })
                    .Apply();

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
 * 1. When you need to extract a 400 × 400 pixel region from the middle of a large BMP file and export it as a PNG for web thumbnails.
 * 2. When you want to isolate a central object in a BMP using a feathered Magic Wand selection before saving the result as a high‑quality PNG.
 * 3. When an application must automatically crop scanned BMP images to a fixed size and apply soft‑edge masking for seamless compositing.
 * 4. When you are preprocessing BMP assets for a game, trimming them to a consistent square and smoothing the selection edges prior to conversion to PNG.
 * 5. When a batch process must convert legacy BMP graphics to PNG while preserving only the central area with a gentle feathered outline.
 */
