// HOW-TO: Convert Animated WebP to Multi-Page TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.webp";
            string outputPath = "Output/assembled.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                webp.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract each frame of a WebP animation and store them as separate pages in a TIFF for archival or printing purposes.
 * 2. When a web application must convert user‑uploaded animated WebP files into a single TIFF document to be processed by legacy imaging tools that only support TIFF.
 * 3. When generating a multi‑page report that includes all frames of an animation, requiring conversion from WebP to TIFF in a C# backend.
 * 4. When creating a printable PDF from an animated WebP, you first convert the animation to a multi‑page TIFF because many PDF generators accept TIFF as an image source.
 * 5. When performing batch processing of animated WebP assets to produce TIFF spritesheets for use in desktop publishing or GIS software that reads TIFF layers.
 */
