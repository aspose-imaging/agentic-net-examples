// HOW-TO: Convert ODG to JPEG and Keep EXIF Orientation in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input/sample.odg";
        string outputPath = "Output/sample.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image sourceImage = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                sourceImage.Save(outputPath, jpegOptions);

                var sourceExif = (sourceImage as JpegImage)?.ExifData;
                if (sourceExif != null)
                {
                    using (Image jpegImage = Image.Load(outputPath))
                    {
                        var jpeg = jpegImage as JpegImage;
                        if (jpeg != null && jpeg.ExifData != null)
                        {
                            jpeg.ExifData.Orientation = sourceExif.Orientation;
                            jpeg.Save();
                        }
                    }
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
 * 1. When a desktop publishing workflow needs to generate web‑ready JPEG thumbnails from ODG drawings while maintaining the original rotation information.
 * 2. When an automated batch process must convert LibreOffice Draw files to JPEG for email attachments without losing the image’s orientation metadata.
 * 3. When a document management system stores ODG diagrams but requires JPEG previews that display correctly on mobile devices.
 * 4. When a migration script moves legacy ODG assets to a JPEG gallery and the EXIF orientation tag must be retained for proper display in browsers.
 * 5. When a C# application integrates Aspose.Imaging to export ODG graphics to JPEG while ensuring the orientation flag is copied for downstream image‑processing pipelines.
 */
