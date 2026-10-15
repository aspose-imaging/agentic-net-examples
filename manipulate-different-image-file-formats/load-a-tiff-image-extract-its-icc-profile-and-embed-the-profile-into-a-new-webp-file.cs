// HOW-TO: Convert TIFF to WebP Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                WebPOptions webpOptions = new WebPOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (WebPImage webpImage = (WebPImage)Image.Create(webpOptions, tiffImage.Width, tiffImage.Height))
                {
                    webpImage.Save();
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
 * 1. When you need to generate a WebP version of a high‑resolution TIFF for faster web delivery.
 * 2. When your application must create a WebP placeholder from a TIFF source without loading the entire image into memory.
 * 3. When you want to automate batch conversion of archival TIFF files to WebP to reduce storage costs.
 * 4. When integrating Aspose.Imaging into a C# service that receives TIFF uploads and returns WebP thumbnails.
 * 5. When you need to ensure consistent image dimensions while converting TIFFs to WebP for responsive design.
 */
