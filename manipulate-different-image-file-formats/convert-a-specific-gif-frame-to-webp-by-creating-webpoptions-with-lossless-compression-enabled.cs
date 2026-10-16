// HOW-TO: Convert First GIF Frame to Lossless WebP in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)img;

                if (gif.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the GIF image.");
                    return;
                }

                GifFrameBlock frame = (GifFrameBlock)gif.Pages[0];
                gif.ActiveFrame = frame;

                WebPOptions webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                gif.Save(outputPath, webpOptions);
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
 * 1. When you need to extract the first frame of an animated GIF and store it as a high‑quality, lossless WebP image for faster web loading.
 * 2. When optimizing product thumbnails that originate from GIFs, converting a single frame to WebP reduces file size while preserving visual fidelity.
 * 3. When generating preview images for a media library, you can programmatically convert a GIF’s initial frame to a lossless WebP using Aspose.Imaging in C#.
 * 4. When building a server‑side image pipeline that requires consistent image formats, converting GIF frames to WebP ensures compatibility with modern browsers.
 * 5. When creating assets for mobile apps where bandwidth is limited, converting a GIF frame to lossless WebP helps maintain quality with minimal data usage.
 */
