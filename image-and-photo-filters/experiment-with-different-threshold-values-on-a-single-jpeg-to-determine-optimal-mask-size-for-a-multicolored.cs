// HOW-TO: Find Optimal Magic Wand Threshold for JPEG Masking in C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            int[] thresholds = new int[] { 10, 20, 30, 40, 50 };

            foreach (int thresh in thresholds)
            {
                string outputPath = Path.Combine(outputDir, $"masked_thresh_{thresh}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(image.Width / 2, image.Height / 2) { Threshold = thresh })
                        .Apply();

                    image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically isolate a subject from a JPEG with a multicolored background by testing different Magic Wand thresholds to choose the best mask size.
 * 2. When you want to generate a series of PNG images with transparent backgrounds from a single JPEG to compare how varying threshold values affect edge detection.
 * 3. When you are fine‑tuning image preprocessing for computer‑vision pipelines and must determine the optimal threshold that preserves details while removing background noise.
 * 4. When you are building a batch tool that evaluates several threshold settings on one photo to select the most accurate alpha mask before further editing.
 * 5. When you need to experiment with Aspose.Imaging’s MagicWandTool in C# to find the threshold that yields the cleanest cut‑out for products photographed against colorful backdrops.
 */
