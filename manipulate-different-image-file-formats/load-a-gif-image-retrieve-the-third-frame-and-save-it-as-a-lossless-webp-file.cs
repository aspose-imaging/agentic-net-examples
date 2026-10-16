// HOW-TO: Extract Third Frame from GIF and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
        const string inputPath = "input.gif";
        const string outputPath = "output/output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount < 3)
                {
                    Console.Error.WriteLine("GIF does not contain at least three frames.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[2];

                var options = new WebPOptions
                {
                    Lossless = true
                };

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
 * 1. When you need to isolate a specific animation frame from a GIF for use in a high‑quality web asset, you can extract the third frame and convert it to a lossless WebP file.
 * 2. When creating thumbnails or preview images from animated GIFs while preserving visual fidelity, extracting a chosen frame and saving it as lossless WebP reduces file size without quality loss.
 * 3. When generating assets for responsive design that require a single static image from an animated source, you can programmatically select the third GIF frame and output it as a WebP image in a .NET application.
 * 4. When processing user‑uploaded GIFs to extract a particular frame for further editing or watermarking, converting that frame to lossless WebP ensures compatibility with modern browsers.
 * 5. When building a server‑side image pipeline that converts animated GIF frames to modern formats, extracting the third frame and saving it as lossless WebP enables efficient storage and fast delivery.
 */
