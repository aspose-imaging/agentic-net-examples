// HOW-TO: Extract GIF Frames to PNG and Log Transparency Status in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputGifPath = "Input/animation.gif";
            string outputDirectory = "Output";

            if (!File.Exists(inputGifPath))
            {
                Console.Error.WriteLine($"File not found: {inputGifPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (GifImage gif = (GifImage)Image.Load(inputGifPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    GifFrameBlock frame = (GifFrameBlock)gif.Pages[i];
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        frame.Save(outputPath, pngOptions);
                    }

                    using (RasterImage png = (RasterImage)Image.Load(outputPath))
                    {
                        bool hasTransparency = png.HasTransparentColor;
                        Console.WriteLine($"Frame {i}: Transparent = {hasTransparency}");
                    }
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
 * 1. When you need to verify that each frame extracted from an animated GIF retains its alpha channel before using the PNGs in a web carousel.
 * 2. When performing quality assurance on converted assets to ensure transparent regions are preserved for UI overlays.
 * 3. When generating individual PNG frames from a GIF for a sprite sheet and you must log which frames contain transparency.
 * 4. When automating a pipeline that converts animated GIFs to PNG sequences and requires a transparency report for compliance with design guidelines.
 * 5. When debugging image processing workflows and need to confirm that the HasTransparentColor property correctly reflects the presence of transparent pixels in each exported frame.
 */
