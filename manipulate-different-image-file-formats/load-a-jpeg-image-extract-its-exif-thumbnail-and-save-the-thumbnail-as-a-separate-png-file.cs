// HOW-TO: Extract EXIF Thumbnail from JPEG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

namespace ExifThumbnailExtractor
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "thumbnail.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
                {
                    var thumbnail = jpeg.ExifData?.Thumbnail;
                    if (thumbnail == null)
                    {
                        Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                        return;
                    }

                    using (thumbnail)
                    {
                        var pngOptions = new PngOptions();
                        thumbnail.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to generate quick preview images from a large collection of JPEG photos by extracting their embedded EXIF thumbnails and converting them to PNG for web display.
 * 2. When building a digital asset management system that must catalog image metadata and store low‑resolution thumbnails separately for faster browsing.
 * 3. When creating a mobile app that reads camera‑generated JPEG files and extracts the EXIF thumbnail to use as a placeholder while the full‑size image loads.
 * 4. When migrating legacy photo archives and you want to preserve the original EXIF thumbnail as a standalone PNG file for archival or indexing purposes.
 * 5. When implementing a server‑side image processing pipeline that validates the presence of an EXIF thumbnail in uploaded JPEGs and saves it as a PNG for further analysis.
 */
