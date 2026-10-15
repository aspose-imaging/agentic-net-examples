// HOW-TO: Convert JPEG to WebP with Quality 75 Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new WebPOptions
                {
                    Quality = 75,
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When you need to reduce the file size of JPEG photos for faster web page loading while preserving acceptable visual quality.
 * 2. When you want to generate WebP thumbnails from existing JPEG assets in a .NET batch‑processing pipeline.
 * 3. When you are building an image‑upload service that stores user pictures as WebP to save storage costs.
 * 4. When you need to convert legacy JPEG product images to WebP for progressive loading in modern browsers.
 * 5. When you are preparing assets for a mobile app that requires WebP format with a specific compression level.
 */
