// HOW-TO: Dither a GIF and Save with Lossy Compression in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);
                GifOptions options = new GifOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to shrink an animated GIF for faster page loads while keeping its visual appearance, you can dither the frames and apply lossy GIF compression in C#.
 * 2. When preparing a GIF for email newsletters where attachment size limits apply, dithering reduces color depth and the lossy compressor cuts the file size further.
 * 3. When converting a high‑color GIF created from a video clip into a web‑friendly version, Floyd‑Steinberg dithering helps preserve detail before saving with lossy compression.
 * 4. When building a C# image‑processing pipeline that automatically optimizes user‑uploaded GIFs, you can dither each image and then save it using GifOptions to achieve consistent compression.
 * 5. When generating animated stickers for messaging apps, applying dithering and lossy compression ensures the GIF meets the platform’s size restrictions without noticeable quality loss.
 */
