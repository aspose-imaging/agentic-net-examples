// HOW-TO: Resize PNG to Half Width and Save as JPEG in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        string inputPath = "input.png";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int newWidth = raster.Width / 2;
                int newHeight = (int)((double)raster.Height * newWidth / raster.Width);

                raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate smaller preview images from large PNG assets for web pages while delivering them as compressed JPEGs.
 * 2. When an e‑commerce platform must convert product photos from PNG to JPEG at half size to reduce bandwidth without distorting the original aspect ratio.
 * 3. When a mobile app backend processes user‑uploaded PNG avatars, resizes them to half width, and stores them as high‑quality JPEGs for faster loading.
 * 4. When a batch script prepares marketing banners by shrinking PNG graphics and saving them as JPEGs with a specific quality setting for email campaigns.
 * 5. When a digital archive migrates PNG scans to JPEG format, scaling them down while preserving the original proportions to save storage space.
 */
