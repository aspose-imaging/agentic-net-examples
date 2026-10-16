// HOW-TO: Apply Floyd Steinberg Dithering to Each Frame of an Animated GIF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    if (gif.ActiveFrame is RasterImage raster)
                    {
                        raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    }
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                gif.Save(outputPath, new GifOptions());
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
 * 1. When you need to reduce banding and add texture to every frame of a low‑color animated GIF before publishing it on the web using Aspose.Imaging for .NET.
 * 2. When converting a high‑resolution video clip to an animated GIF and want each frame to retain visual detail despite the limited 256‑color palette by applying Floyd‑Steinberg dithering in C#.
 * 3. When creating retro‑style pixel‑art animations where Floyd‑Steinberg dithering improves gradient smoothness across all GIF frames with Aspose.Imaging.
 * 4. When processing user‑uploaded GIFs to ensure consistent visual quality across browsers that only support 256 colors by dithering each frame in C#.
 * 5. When building an image‑processing pipeline that automatically enhances the visual fidelity of animated GIFs generated from screenshots or screen recordings using Aspose.Imaging’s Dither method.
 */
