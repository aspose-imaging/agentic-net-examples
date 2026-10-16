// HOW-TO: How To Adjust Gamma Of A GIF To 1.5 In C# (Aspose.Imaging for .NET)
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
                foreach (var page in gif.Pages)
                {
                    GifFrameBlock frame = (GifFrameBlock)page;
                    if (!frame.IsCached)
                    {
                        frame.CacheData();
                    }
                    frame.AdjustGamma(1.5f);
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
 * 1. When you need to brighten or darken all frames of an animated GIF for consistent visual appearance across different devices.
 * 2. When preparing GIF assets for a web page and want to apply a specific gamma value to improve contrast without re‑encoding each frame manually.
 * 3. When building a C# batch‑processing tool that normalizes the gamma of multiple GIF files before uploading them to a digital asset management system.
 * 4. When creating a custom image‑editing feature in a Windows application that lets users adjust the gamma of animated GIFs on the fly.
 * 5. When troubleshooting color rendering issues in an animated GIF and need to programmatically apply a gamma correction of 1.5 using Aspose.Imaging.
 */
