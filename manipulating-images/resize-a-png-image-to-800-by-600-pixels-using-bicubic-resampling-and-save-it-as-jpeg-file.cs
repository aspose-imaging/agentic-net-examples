// HOW-TO: Resize PNG to 800x600 and Convert to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(800, 600, ResizeType.NearestNeighbourResample);

                JpegOptions jpegOptions = new JpegOptions();
                jpegOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate web‑ready JPEG thumbnails from high‑resolution PNG assets in a C# application.
 * 2. When a batch process must downsize product images to a fixed 800×600 size before uploading to an e‑commerce platform.
 * 3. When converting PNG screenshots to JPEG to reduce file size while preserving dimensions in an automated reporting tool.
 * 4. When preparing images for email newsletters that require JPEG format and a specific 800×600 resolution using Aspose.Imaging.
 * 5. When migrating legacy PNG graphics to JPEG for compatibility with a third‑party system that only accepts JPEG files of 800×600 pixels.
 */
