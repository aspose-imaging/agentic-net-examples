// HOW-TO: Adjust Gamma of PNG Frames and Create Balanced Animated GIF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = { "frame1.png", "frame2.png", "frame3.png" };
            string outputPath = "output/animated.gif";

            // Verify input files exist
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load images, adjust gamma, and collect them
            List<Image> frames = new List<Image>();
            float gammaValue = 1.2f; // Example gamma adjustment

            foreach (var inputPath in inputPaths)
            {
                RasterImage raster = (RasterImage)Image.Load(inputPath);
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }
                raster.AdjustGamma(gammaValue);
                frames.Add(raster);
            }

            // Create animated GIF from frames
            Image animatedGif = Image.Create(frames.ToArray(), true);
            GifOptions gifOptions = new GifOptions();
            animatedGif.Save(outputPath, gifOptions);
            animatedGif.Dispose();

            // Dispose individual frames
            foreach (var img in frames)
            {
                img.Dispose();
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
 * 1. When you need to correct the brightness of a series of PNG images before turning them into a smooth animated GIF for a web banner.
 * 2. When you want to programmatically apply a gamma correction to each frame of a slideshow to ensure consistent luminance across all frames in a C# application.
 * 3. When you are building a desktop tool that combines multiple cached raster images into an animated GIF while preserving color balance using Aspose.Imaging.
 * 4. When you must generate an animated GIF from user‑uploaded images and need to adjust gamma to compensate for varying lighting conditions in the source files.
 * 5. When you are automating the creation of GIF animations for email newsletters and require a simple C# script to adjust gamma and output a ready‑to‑use GIF file.
 */
