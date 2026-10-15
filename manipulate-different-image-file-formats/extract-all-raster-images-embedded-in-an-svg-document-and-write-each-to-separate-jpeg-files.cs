// HOW-TO: Extract Embedded Raster Images from SVG and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.svg";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                var vectorImage = (VectorImage)image;
                var embeddedImages = vectorImage.GetEmbeddedImages();
                int index = 0;
                foreach (var embedded in embeddedImages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"embedded_{index++}.jpg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    using (embedded)
                    {
                        embedded.Image.Save(outputPath, new JpegOptions());
                    }
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
 * 1. When you need to extract all raster graphics embedded in an SVG logo and convert them to JPEG files for use in a legacy web application.
 * 2. When a design workflow requires separating bitmap assets from an SVG illustration to generate high‑resolution JPEG thumbnails for a product catalog.
 * 3. When an automated build script must process SVG icons and output each embedded image as a JPEG to comply with a content management system’s image format restrictions.
 * 4. When a mobile app backend has to retrieve raster images stored inside SVG files and store them as JPEGs for faster loading on low‑bandwidth devices.
 * 5. When a reporting tool needs to convert embedded SVG images into JPEGs to embed them into PDF or Word documents that do not support vector graphics.
 */
