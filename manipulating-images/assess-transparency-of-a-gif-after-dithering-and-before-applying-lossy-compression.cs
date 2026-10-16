// HOW-TO: Check GIF Frame Transparency After Dithering In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.gif";
        string outputPath = "output\\output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    GifFrameBlock frame = (GifFrameBlock)gif.Pages[i];
                    frame.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                    int width = frame.Width;
                    int height = frame.Height;
                    int[] pixels = new int[width * height];
                    frame.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                    bool hasTransparency = pixels.Any(p => ((p >> 24) & 0xFF) < 255);
                    Console.WriteLine($"Frame {i} has transparency: {hasTransparency}");
                }

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
 * 1. When you need to verify whether each frame of an animated GIF still contains transparent pixels after applying Floyd‑Steinberg dithering before further compression.
 * 2. When you want to programmatically detect and log transparency in GIF frames to decide if a lossless or lossy compression strategy should be used.
 * 3. When you are preprocessing GIF assets for web delivery and must ensure that dithering does not unintentionally remove or alter transparency information.
 * 4. When you are building a batch image‑processing tool that analyses animated GIFs and reports frames that require special handling because they contain semi‑transparent pixels.
 * 5. When you need to combine Aspose.Imaging’s dithering capabilities with pixel‑level inspection to maintain visual quality while preparing GIFs for mobile apps.
 */
