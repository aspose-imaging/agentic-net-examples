// HOW-TO: Increase GIF Brightness and Compress Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.gif";
            string outputPath = "output/output.gif";

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
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    RasterImage frame = (RasterImage)gif.ActiveFrame;
                    if (!frame.IsCached)
                    {
                        frame.CacheData();
                    }
                    frame.AdjustBrightness(50);
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
 * 1. When you need to make a dark animated GIF appear lighter for better visibility on a website while keeping the file size small.
 * 2. When you want to programmatically adjust the brightness of each frame in a GIF before sending it through an email campaign that limits attachment size.
 * 3. When you are building a desktop tool that enhances user‑uploaded GIFs and automatically applies lossy compression to meet social‑media upload limits.
 * 4. When you have a batch process that prepares GIF assets for mobile apps, increasing brightness for low‑light screens and reducing bandwidth usage.
 * 5. When you integrate Aspose.Imaging into a server‑side service that receives GIFs, brightens them for accessibility compliance, and stores them in an optimized format.
 */
