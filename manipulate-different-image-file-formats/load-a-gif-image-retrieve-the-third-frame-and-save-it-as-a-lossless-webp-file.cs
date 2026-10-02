// HOW-TO: Extract Third Frame from GIF and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output\\frame3.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount <= 2)
                {
                    Console.Error.WriteLine("The GIF does not contain a third frame.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[2];

                WebPOptions options = new WebPOptions
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
 * 1. When you need to isolate a specific animation frame from a GIF for use in a high‑quality web asset, you can extract the third frame and convert it to a lossless WebP with Aspose.Imaging in C#.
 * 2. When generating thumbnails or preview images from animated GIFs, extracting a particular frame and saving it as a WebP reduces file size while preserving visual fidelity.
 * 3. When creating a sprite sheet or UI element that requires a single frame from an animated GIF, converting that frame to lossless WebP ensures fast loading on modern browsers.
 * 4. When processing user‑uploaded GIFs to extract a key frame for machine‑learning analysis, saving the frame as lossless WebP maintains pixel‑perfect data for accurate results.
 * 5. When migrating legacy GIF animations to a modern image format, extracting individual frames and storing them as lossless WebP files simplifies the transition while keeping the original quality.
 */
