// HOW-TO: Crop JPEG Image with Offsets and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

namespace ImageCropper
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output\\cropped.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
                {
                    if (!rasterImage.IsCached)
                    {
                        rasterImage.CacheData();
                    }

                    int left = 10;
                    int right = 10;
                    int top = 10;
                    int bottom = 10;

                    rasterImage.Crop(left, right, top, bottom);
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to remove unwanted borders from a scanned JPEG photo before converting it to a PNG for web display.
 * 2. When an e‑commerce platform must generate thumbnail PNGs from product JPEGs by cropping a fixed number of pixels on each side.
 * 3. When a batch‑processing tool has to trim a uniform margin from uploaded JPEG avatars and store the result as lossless PNG files.
 * 4. When a reporting system extracts a specific region from a JPEG chart by applying left, top, right, and bottom offsets and saves it as a PNG for inclusion in PDFs.
 * 5. When a mobile app backend prepares user‑submitted JPEG images by cropping them to a standard size and converting them to PNG for consistent rendering across devices.
 */
