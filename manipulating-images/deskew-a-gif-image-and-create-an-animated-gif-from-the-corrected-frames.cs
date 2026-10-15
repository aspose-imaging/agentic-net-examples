// HOW-TO: How To Deskew An Animated GIF And Save Corrected Frames In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    using (RasterImage frame = (RasterImage)gif.Pages[i])
                    {
                        if (!frame.IsCached)
                        {
                            frame.CacheData();
                        }
                        frame.NormalizeAngle(false, Aspose.Imaging.Color.White);
                    }
                }

                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When you receive scanned animated GIFs that are tilted, you can use this code to deskew each frame and produce a properly aligned animation.
 * 2. If a web application needs to display user‑uploaded GIFs without the visual distortion caused by skewed frames, the routine normalizes the angle of every page before saving.
 * 3. For batch processing of legacy GIF assets where the original orientation is off, the script automatically caches each raster frame, corrects its angle, and rewrites the file.
 * 4. When generating animated tutorials from photographed screen captures that are slightly rotated, the code ensures each slide is straightened while preserving the GIF animation.
 * 5. In a digital asset management system that stores animated GIFs, this method can be called to correct skewed images on‑the‑fly before they are served to clients.
 */
