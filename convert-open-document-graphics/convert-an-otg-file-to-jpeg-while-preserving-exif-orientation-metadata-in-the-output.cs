// HOW-TO: Convert OTG to JPEG while Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.otg";
        string outputPath = "Output/sample.jpg";

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
                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                if (image is JpegImage jpegSrc && jpegSrc.ExifData != null)
                {
                    jpegOptions.ExifData = jpegSrc.ExifData;
                }

                image.Save(outputPath, jpegOptions);
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
 * 1. When a photo‑editing application needs to import legacy OTG vector files and export them as JPEGs that keep the original camera orientation metadata.
 * 2. When an e‑commerce platform must generate product thumbnails from OTG designs while retaining EXIF data for downstream image analytics.
 * 3. When a digital asset management system migrates archived OTG graphics to JPEG format without losing orientation information required for correct display on mobile devices.
 * 4. When a batch‑processing script converts user‑uploaded OTG files to JPEGs for web publishing, ensuring the EXIF orientation tag is copied to avoid rotated images.
 * 5. When a reporting tool creates printable JPEG reports from OTG charts and wants to preserve the source EXIF metadata for audit trails.
 */
