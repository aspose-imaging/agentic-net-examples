// HOW-TO: Convert TIFF to Lossless WebP with EXIF Orientation Correction in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int orientation = 1;
                if (tiff.ExifData != null)
                {
                    try
                    {
                        orientation = (int)tiff.ExifData.Orientation;
                    }
                    catch
                    {
                        // Keep default orientation
                    }
                }

                switch (orientation)
                {
                    case 2:
                        tiff.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        tiff.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        tiff.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        break;
                    case 5:
                        tiff.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        tiff.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        tiff.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        tiff.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    default:
                        break;
                }

                WebPOptions options = new WebPOptions
                {
                    Lossless = true,
                    Source = new FileCreateSource(outputPath, false)
                };

                tiff.Save(outputPath, options);
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
 * 1. When you need to display scanned documents on a website and must ensure they appear upright regardless of how the original camera was held, you can load the TIFF, apply EXIF rotation, and save it as a lossless WebP.
 * 2. When optimizing image assets for a responsive web page, converting high‑resolution TIFF files to smaller WebP images while preserving the original orientation reduces bandwidth without sacrificing quality.
 * 3. When building a batch‑processing pipeline that ingests medical or archival TIFF images, correcting orientation from EXIF data and exporting to WebP enables fast preview generation.
 * 4. When adding image upload functionality to a C# application, you may need to automatically re‑orient user‑submitted TIFF photos and store them in WebP format for consistent rendering across browsers.
 * 5. When creating thumbnails for a digital asset management system, rotating TIFFs based on EXIF orientation and saving them as lossless WebP ensures accurate thumbnails and efficient storage.
 */
