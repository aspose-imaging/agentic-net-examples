// HOW-TO: Extract Fifth Frame from GIF and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount < 5)
                {
                    Console.Error.WriteLine("GIF does not contain at least 5 frames.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[4];

                using (RasterImage frame = (RasterImage)gif.ActiveFrame)
                {
                    WebPOptions options = new WebPOptions
                    {
                        Lossless = true
                    };
                    frame.Save(outputPath, options);
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
 * 1. When you need to isolate a specific animation frame from a GIF to use as a high‑quality thumbnail in a web application, you can extract the fifth frame and convert it to a lossless WebP file.
 * 2. When optimizing assets for a mobile app, extracting a particular GIF frame and saving it as lossless WebP reduces file size while preserving visual fidelity.
 * 3. When generating a sprite sheet from an animated GIF, you may extract individual frames—such as the fifth one—and store them in WebP format for faster rendering.
 * 4. When creating a preview image for a video editor that supports WebP, you can pull the fifth frame from a GIF source and save it losslessly for accurate color representation.
 * 5. When processing user‑uploaded GIFs in a C# backend and needing to reuse a specific frame in a PDF report, converting that frame to lossless WebP ensures compatibility and crisp quality.
 */
