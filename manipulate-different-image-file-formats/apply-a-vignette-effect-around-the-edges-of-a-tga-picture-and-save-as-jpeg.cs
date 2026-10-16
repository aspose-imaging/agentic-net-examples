// HOW-TO: Add Vignette Effect to TGA Image and Save as JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.tga";
        string outputPath = "Output\\result.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;
                int radius = (int)(Math.Min(raster.Width, raster.Height) * 0.4);

                var mask = MagicWandTool.Select(raster, new MagicWandSettings(centerX, centerY))
                    .Union(new CircleMask(centerX, centerY, radius))
                    .Invert()
                    .GetFeathered(new FeatheringSettings { Size = 30 });

                mask.Apply();

                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to create a photo‑style vignette around a TGA texture before publishing it as a JPEG for web galleries.
 * 2. When converting legacy TGA assets from a game project into compressed JPEGs while adding a soft border to focus viewer attention.
 * 3. When generating thumbnails with a darkened edge effect for an e‑commerce catalog that stores product images originally in TGA format.
 * 4. When preparing print‑ready images by applying a feathered mask to the edges of a TGA file and exporting it as a high‑quality JPEG.
 * 5. When automating batch processing of TGA screenshots to add a professional vignette and store the results in JPEG for email distribution.
 */
