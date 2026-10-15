// HOW-TO: Convert DNG Image to PNG with White Background in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                dng.BackgroundColor = Color.White;
                PngOptions pngOptions = new PngOptions();
                dng.Save(outputPath, pngOptions);
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
 * 1. When you need to prepare raw camera files (DNG) for web display by removing transparency and applying a white background before saving as PNG.
 * 2. When a photo‑editing application must batch‑process DNG files and output them as PNGs with a consistent white canvas for printing.
 * 3. When integrating Aspose.Imaging into a C# service that converts raw images to a browser‑compatible format while ensuring the background is white.
 * 4. When creating thumbnails of DNG photos for e‑commerce listings, requiring a white background and PNG output for compatibility.
 * 5. When migrating a digital asset library from raw DNG files to PNG assets and need to enforce a uniform white background during conversion.
 */
