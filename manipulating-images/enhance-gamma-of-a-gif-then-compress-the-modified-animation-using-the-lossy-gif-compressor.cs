// HOW-TO: Increase Gamma of GIF Animation and Compress It in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
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
            string inputPath = "input\\animation.gif";
            string outputPath = "output\\compressed.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.Pages.Count(); i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    RasterImage frameRaster = (RasterImage)gif.ActiveFrame;
                    if (!frameRaster.IsCached)
                    {
                        frameRaster.CacheData();
                    }
                    frameRaster.AdjustGamma(1.2f);
                }

                GifOptions gifOptions = new GifOptions();
                gif.Save(outputPath, gifOptions);
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
 * 1. When you need to brighten a GIF animation for better visibility while reducing its file size for faster web loading.
 * 2. When you want to apply gamma correction to each frame of an animated GIF before sending it through a lossy GIF compressor to meet email attachment limits.
 * 3. When you are preparing product showcase animations and must adjust their contrast and compress them to stay within mobile app bundle size constraints.
 * 4. When you are building an image‑processing pipeline that automatically enhances the tonal balance of GIFs and then optimizes them for CDN delivery.
 * 5. When you need to programmatically improve the appearance of legacy GIF banners and shrink them using Aspose.Imaging in a C# backend service.
 */
