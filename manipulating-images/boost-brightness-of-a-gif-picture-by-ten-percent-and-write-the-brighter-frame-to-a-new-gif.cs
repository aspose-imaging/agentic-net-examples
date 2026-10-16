// HOW-TO: Increase GIF Brightness By 10 Percent And Save New GIF In C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount > 0)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
                    using (RasterImage raster = (RasterImage)gif.ActiveFrame)
                    {
                        if (!raster.IsCached)
                        {
                            raster.CacheData();
                        }
                        // Increase brightness by approximately 10% of the max value (255 * 0.10 ≈ 26)
                        raster.AdjustBrightness(26);
                    }
                    gif.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The GIF contains no frames.");
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
 * 1. When a web developer uses Aspose.Imaging for .NET to brighten animated GIF ads so they stand out against a dark website background.
 * 2. When a desktop app automatically enhances user‑uploaded GIF avatars by increasing brightness with C# before saving them to the profile folder.
 * 3. When a batch‑processing script needs to adjust the brightness of multiple GIF frames to comply with accessibility contrast standards.
 * 4. When an e‑learning platform generates instructional GIFs and wants to boost their brightness programmatically to improve on‑screen readability.
 * 5. When a digital signage system brightens GIF animations on the fly with C# to compensate for bright ambient lighting in public spaces.
 */
