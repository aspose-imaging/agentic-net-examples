// HOW-TO: Find Optimal Binarization Threshold for JPEG to PNG Masks in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-29
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            byte[] thresholds = new byte[] { 50, 100, 150, 200 };

            foreach (byte threshold in thresholds)
            {
                string outputPath = Path.Combine(outputDirectory, $"mask_{threshold}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterCachedImage img = (RasterCachedImage)Image.Load(inputPath))
                {
                    if (!img.IsCached) img.CacheData();
                    img.BinarizeFixed(threshold);

                    var rect = new Rectangle(0, 0, img.Width, img.Height);
                    int[] pixels = img.LoadArgb32Pixels(rect);
                    long whiteCount = 0;
                    foreach (int pixel in pixels)
                    {
                        if ((uint)pixel == 0xFFFFFFFF) whiteCount++;
                    }
                    Console.WriteLine($"Threshold {threshold}: White pixels = {whiteCount}");

                    img.Save(outputPath, new PngOptions());
                }
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
 * 1. When you need to generate binary mask images from a JPEG with varying thresholds to evaluate which threshold best isolates a multicolored background.
 * 2. When you want to count white pixels after binarization to measure how much of the image is foreground for quality analysis.
 * 3. When you are creating pre‑processing steps for OCR or computer‑vision pipelines that require a black‑and‑white mask of a JPEG source.
 * 4. When you need to batch‑process a single JPEG with multiple threshold values and automatically save each resulting mask as a PNG file.
 * 5. When you are debugging image segmentation by comparing the effect of different fixed thresholds on the same picture.
 */
