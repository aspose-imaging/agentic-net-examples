// HOW-TO: Select Sky Region in PNG with Magic Wand and Invert Selection in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10) { Threshold = 70 })
                    .Invert()
                    .Apply();

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically isolate and edit the sky area of a landscape PNG for color correction or replacement.
 * 2. When building a photo‑editing tool that lets users remove or mask the sky by selecting it with a tolerance threshold.
 * 3. When generating thumbnails that require the sky to be excluded from the visible region to focus on foreground details.
 * 4. When preparing images for compositing and you must invert the sky selection to keep only the ground and objects.
 * 5. When automating batch processing of outdoor photos to apply effects only to non‑sky parts by selecting the sky first and then inverting the mask.
 */
