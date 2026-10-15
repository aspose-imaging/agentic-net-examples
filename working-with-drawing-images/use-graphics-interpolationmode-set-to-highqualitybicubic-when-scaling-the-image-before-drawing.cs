// HOW-TO: Scale PNG Image with High Quality Bicubic Interpolation in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Aspose.Imaging.Image srcImage = Aspose.Imaging.Image.Load(inputPath))
            {
                int newWidth = srcImage.Width * 2;
                int newHeight = srcImage.Height * 2;

                using (Aspose.Imaging.Image destImage = Aspose.Imaging.Image.Create(new PngOptions(), newWidth, newHeight))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(destImage);
                    graphics.InterpolationMode = Aspose.Imaging.InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(srcImage, new Aspose.Imaging.Rectangle(0, 0, newWidth, newHeight));
                    destImage.Save(outputPath);
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
 * 1. When you need to double the resolution of a PNG while preserving visual quality for printing or high‑DPI displays.
 * 2. When generating thumbnails or preview images that require smooth scaling without jagged edges using Aspose.Imaging in a .NET application.
 * 3. When preparing assets for a responsive web design and want to upscale images with high‑quality bicubic interpolation to avoid pixelation.
 * 4. When converting low‑resolution scans into larger images for archival purposes, ensuring the upscaled result retains as much detail as possible.
 * 5. When automating batch image processing in C# and must create larger copies of existing PNG files with consistent high‑quality scaling.
 */
