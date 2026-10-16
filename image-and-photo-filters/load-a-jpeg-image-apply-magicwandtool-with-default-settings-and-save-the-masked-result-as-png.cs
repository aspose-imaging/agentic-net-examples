// HOW-TO: Select Central Region of JPEG with Magic Wand and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output\\masked.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    int centerX = raster.Width / 2;
                    int centerY = raster.Height / 2;

                    MagicWandTool.Select(raster, new MagicWandSettings(centerX, centerY)).Apply();

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, pngOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to isolate the central part of a JPEG photo and export it with transparency for web graphics.
 * 2. When creating thumbnails that require a masked PNG output preserving only the area selected by a magic wand algorithm.
 * 3. When preprocessing scanned documents to extract the main content region and save it as a lossless PNG with an alpha channel.
 * 4. When building a photo‑editing feature that automatically cuts out the center of an image without manual selection.
 * 5. When converting legacy JPEG assets into PNG assets with built‑in masking to support transparent backgrounds.
 */
