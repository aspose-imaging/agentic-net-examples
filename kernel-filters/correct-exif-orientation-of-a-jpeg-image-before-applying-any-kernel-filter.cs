// HOW-TO: Correct JPEG EXIF Orientation Before Applying Filters In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    ushort orientationValue = (ushort)exif.Orientation;
                    switch (orientationValue)
                    {
                        case 3:
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6:
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                }

                var options = new JpegOptions
                {
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
 * 1. When a web application receives user‑uploaded photos that appear sideways because the camera’s EXIF orientation tag is set, you can use this code to normalize the JPEG so it displays correctly across browsers.
 * 2. When preparing images for a machine‑learning pipeline that expects upright pictures, the routine ensures the JPEG’s orientation is fixed before any convolution or kernel filter is applied.
 * 3. When generating thumbnails for a gallery, correcting the EXIF orientation first prevents rotated thumbnails and guarantees consistent layout on mobile devices.
 * 4. When batch‑processing scanned documents stored as JPEGs, the code rotates them based on EXIF data so that OCR engines receive properly oriented pages.
 * 5. When integrating Aspose.Imaging into a photo‑editing desktop tool, this snippet guarantees that subsequent filters such as blur or sharpen operate on the correctly oriented image.
 */
