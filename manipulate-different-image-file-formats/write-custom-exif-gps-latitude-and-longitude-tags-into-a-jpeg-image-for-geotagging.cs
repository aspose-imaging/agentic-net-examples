// HOW-TO: Add Custom GPS EXIF Tags to JPEG Image in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample_geotagged.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    exif.GPSLatitude = new TiffRational[]
                    {
                        new TiffRational(37, 1),
                        new TiffRational(48, 1),
                        new TiffRational(30, 1)
                    };
                    exif.GPSLatitudeRef = "N";

                    exif.GPSLongitude = new TiffRational[]
                    {
                        new TiffRational(122, 1),
                        new TiffRational(24, 1),
                        new TiffRational(15, 1)
                    };
                    exif.GPSLongitudeRef = "W";
                }

                image.Save(outputPath);
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
 * 1. When a developer needs to geotag photos taken offline by embedding latitude and longitude into the JPEG EXIF metadata using C#.
 * 2. When building a photo‑management app that must add or correct GPS coordinates in existing images without re‑encoding them.
 * 3. When preparing images for mapping services that require precise GPS EXIF tags to display locations on a map.
 * 4. When integrating location data from a GPS device into a batch of JPEG files during an automated upload workflow.
 * 5. When creating a custom image‑processing pipeline that updates EXIF GPS fields before sharing images on social media platforms.
 */
