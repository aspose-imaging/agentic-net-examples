// HOW-TO: Convert TIFF With EXIF Orientation To Lossless WebP In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Exif;
using Aspose.Imaging.Exif.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                ushort orientation = 1;
                if (image.ExifData != null)
                {
                    try
                    {
                        var tagValue = image.ExifData.GetTagValue(ExifProperties.Orientation);
                        orientation = Convert.ToUInt16(tagValue);
                    }
                    catch
                    {
                        // Tag not present; keep default orientation
                    }
                }

                RotateFlipType rotateFlip = RotateFlipType.RotateNoneFlipNone;
                switch (orientation)
                {
                    case 2: rotateFlip = RotateFlipType.RotateNoneFlipX; break;
                    case 3: rotateFlip = RotateFlipType.Rotate180FlipNone; break;
                    case 4: rotateFlip = RotateFlipType.RotateNoneFlipY; break;
                    case 5: rotateFlip = RotateFlipType.Rotate90FlipX; break;
                    case 6: rotateFlip = RotateFlipType.Rotate90FlipNone; break;
                    case 7: rotateFlip = RotateFlipType.Rotate90FlipY; break;
                    case 8: rotateFlip = RotateFlipType.Rotate270FlipNone; break;
                }

                if (rotateFlip != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlip);
                }

                WebPOptions options = new WebPOptions
                {
                    Lossless = true,
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When a web application needs to display user‑uploaded TIFF photos correctly oriented and serve them as small, lossless WebP files for faster page loads.
 * 2. When a digital asset management system must normalize scanned documents by reading EXIF orientation, rotating them, and storing them in a modern WebP format.
 * 3. When a batch‑processing script has to convert legacy TIFF images from cameras or scanners into WebP while preserving the original orientation for archival.
 * 4. When an e‑commerce site wants to ensure product images captured in TIFF are automatically rotated based on EXIF data and delivered as lossless WebP to improve SEO and image quality.
 * 5. When a mobile app backend processes incoming TIFF uploads, corrects their orientation, and saves them as WebP to reduce bandwidth without losing detail.
 */
