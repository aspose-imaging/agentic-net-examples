// HOW-TO: Invert Magic Wand Selection on TIFF and Fill with White in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Invert()
                    .Apply();

                Color[] pixels = image.LoadPixels(image.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    if (pixels[i].A == 0)
                    {
                        pixels[i] = Color.White;
                    }
                }
                image.SavePixels(image.Bounds, pixels);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to remove unwanted background from a scanned TIFF document by selecting the foreground with a magic wand, inverting the selection, and filling the rest with white.
 * 2. When preparing TIFF images for OCR, you can invert a magic wand selection to isolate text areas and replace transparent regions with white to improve recognition accuracy.
 * 3. When converting multi‑page TIFFs that contain transparent margins, this code lets you fill those margins with white after inverting the selection.
 * 4. When cleaning up old fax TIFF files that have irregular transparent spots, you can use the magic wand inversion to turn those spots into a solid white background.
 * 5. When generating printable TIFFs from images with alpha channels, the technique fills all fully transparent pixels with white after inverting the initial selection.
 */
