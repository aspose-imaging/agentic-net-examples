// HOW-TO: Resize WebP Image to Half Size with High Quality in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("Input file is not a WebP image.");
                    return;
                }

                int newWidth = webp.Width / 2;
                int newHeight = webp.Height / 2;

                webp.Resize(newWidth, newHeight, ResizeType.HighQualityResample);

                WebPOptions options = new WebPOptions
                {
                    Quality = 90,
                    Lossless = false
                };

                webp.Save(outputPath, options);
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
 * 1. When you need to generate smaller thumbnail versions of WebP photos for faster web page loading while preserving visual fidelity.
 * 2. When an e‑commerce platform must reduce the dimensions of product images stored as WebP to meet a maximum file size limit without sacrificing quality.
 * 3. When a mobile app needs to downscale user‑uploaded WebP pictures before uploading them to conserve bandwidth.
 * 4. When a content management system automatically creates optimized WebP previews for galleries by resizing originals to half their size.
 * 5. When a batch‑processing script updates existing WebP assets to a consistent resolution and quality setting for SEO‑friendly image delivery.
 */
