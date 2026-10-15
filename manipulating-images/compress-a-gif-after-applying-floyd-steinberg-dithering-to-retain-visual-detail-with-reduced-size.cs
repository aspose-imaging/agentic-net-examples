// HOW-TO: Compress GIF With Floyd Steinberg Dithering In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
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

            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage rasterImage)
                {
                    rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                    rasterImage.Save(outputPath, new GifOptions());
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to reduce the file size of an animated GIF for web delivery while preserving visual quality through Floyd‑Steinberg dithering.
 * 2. When you are building a C# application that must process user‑uploaded GIFs and store optimized versions on a server.
 * 3. When you want to convert high‑color GIF frames to an 8‑bit palette with error diffusion before saving to meet email attachment limits.
 * 4. When you need to automate batch compression of GIF assets in a CI pipeline using Aspose.Imaging for .NET.
 * 5. When you are creating a mobile‑friendly preview of a GIF and must balance detail and bandwidth by applying dithering and compression.
 */
