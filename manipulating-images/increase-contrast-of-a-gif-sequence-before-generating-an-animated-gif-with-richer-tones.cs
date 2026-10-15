// HOW-TO: Increase Contrast of PNG Frames and Create Animated GIF in C# (Aspose.Imaging for .NET)
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
            string[] inputPaths = new string[] { "frame1.png", "frame2.png", "frame3.png" };
            string outputPath = "output/animated.gif";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            List<Image> frames = new List<Image>();
            foreach (var path in inputPaths)
            {
                Image img = Image.Load(path);
                RasterImage raster = (RasterImage)img;
                if (!raster.IsCached) raster.CacheData();
                raster.AdjustContrast(0.5f);
                frames.Add(img);
            }

            using (Image result = Image.Create(frames.ToArray(), true))
            {
                GifOptions gifOptions = new GifOptions();
                result.Save(outputPath, gifOptions);
            }

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
 * 1. When you need to enhance the visual depth of a series of PNG images before turning them into an animated GIF for a web banner.
 * 2. When you want to programmatically adjust contrast of each frame in a slide show and output a smooth looping GIF using Aspose.Imaging in C#.
 * 3. When an e‑learning platform requires brighter, more vivid animation frames generated from raw PNG assets.
 * 4. When a mobile app creates custom stickers by increasing contrast of user‑uploaded PNGs and packaging them as an animated GIF.
 * 5. When a marketing tool automatically processes product screenshots, boosts their contrast, and assembles them into an animated GIF for social media.
 */
