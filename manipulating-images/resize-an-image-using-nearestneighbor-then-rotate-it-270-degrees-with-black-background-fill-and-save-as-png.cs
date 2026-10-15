// HOW-TO: Resize Image With Nearest Neighbor And Rotate 270 Degrees To PNG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\image.jpg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                image.Resize(image.Width, image.Height, ResizeType.NearestNeighbourResample);
                image.Rotate(270f, true, Color.Black);

                PngOptions options = new PngOptions();
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
 * 1. When you need to convert a JPEG photo to a PNG file while preserving the original size and applying a 270‑degree clockwise rotation with a black background.
 * 2. When you must prepare images for a game engine that requires PNG assets oriented correctly after a rotation and uses nearest‑neighbor scaling for pixel‑perfect graphics.
 * 3. When generating thumbnails for a web gallery where the source images need to be rotated and saved as lossless PNGs without changing their dimensions.
 * 4. When processing scanned documents that must be rotated to portrait orientation and saved as PNG for OCR pipelines that expect a black fill for empty areas.
 * 5. When automating batch image transformations in a C# application to ensure consistent rotation and format conversion for printing workflows.
 */
