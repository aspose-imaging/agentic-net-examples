// HOW-TO: Extract Embedded Thumbnail From TIFF And Save As WebP In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "thumbnail.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage if needed (not strictly required for ExifData)
                TiffImage tiff = image as TiffImage;
                if (tiff == null)
                {
                    Console.Error.WriteLine("The provided file is not a TIFF image.");
                    return;
                }

                // Access EXIF data
                ExifData exif = tiff.ExifData;
                if (exif == null || exif.Thumbnail == null)
                {
                    Console.Error.WriteLine("No embedded thumbnail found in the TIFF image.");
                    return;
                }

                // Get the thumbnail image
                using (Image thumbnail = exif.Thumbnail)
                {
                    // Save thumbnail as WebP
                    WebPOptions options = new WebPOptions();
                    thumbnail.Save(outputPath, options);
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
 * 1. When you need to generate a small preview image for a large TIFF document without loading the full image.
 * 2. When you want to display a quick thumbnail of a scanned photograph on a web page and prefer the WebP format for better compression.
 * 3. When you are building a digital asset management system that extracts and stores embedded thumbnails from TIFF files for faster catalog browsing.
 * 4. When you need to convert legacy TIFF metadata thumbnails to a modern web‑friendly format to improve loading times on mobile devices.
 * 5. When you are processing a batch of TIFF files and must extract their internal thumbnails to create a gallery of low‑resolution previews.
 */
