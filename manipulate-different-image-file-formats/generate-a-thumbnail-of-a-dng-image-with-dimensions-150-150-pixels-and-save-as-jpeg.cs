// HOW-TO: Create 150x150 JPEG Thumbnail From DNG Image In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.dng";
        string outputPath = "Output/thumbnail.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                dng.Resize(150, 150);
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                dng.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate small preview images for raw DNG photos to display in a web gallery, this code creates a 150×150 JPEG thumbnail quickly.
 * 2. When building a digital asset management system that stores raw camera files, you can use this snippet to produce consistent JPEG thumbnails for faster browsing.
 * 3. When optimizing a mobile app that shows camera RAW images, the code resizes DNG files to a fixed 150 px square and saves them as high‑quality JPEGs to reduce bandwidth.
 * 4. When automating batch processing of RAW files on a server, the example demonstrates how to load a DNG, resize it, and export a JPEG thumbnail using Aspose.Imaging for .NET.
 * 5. When integrating raw image support into an e‑commerce platform, this routine creates uniform product preview thumbnails from DNG files without needing external tools.
 */
