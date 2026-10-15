// HOW-TO: Add Thumbnail to JFIF and EXIF Segments of JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = (JpegImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var thumbOptions = new JpegOptions();
                    jpegImage.Save(ms, thumbOptions);
                    ms.Position = 0;
                    using (JpegImage thumbImage = (JpegImage)Aspose.Imaging.Image.Load(ms))
                    {
                        thumbImage.Resize(100, 100, Aspose.Imaging.ResizeType.NearestNeighbourResample);
                        jpegImage.Jfif.Thumbnail = thumbImage;
                        if (jpegImage.ExifData != null)
                        {
                            jpegImage.ExifData.Thumbnail = thumbImage;
                        }
                    }
                }

                jpegImage.Save(outputPath);
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
 * 1. When you need to embed a small preview image in both the JFIF and EXIF metadata of a JPEG so that photo viewers can display thumbnails without loading the full image.
 * 2. When generating image galleries for web or mobile apps and want each JPEG to contain a built‑in thumbnail for faster loading on devices that read EXIF or JFIF data.
 * 3. When creating digital asset pipelines that require consistent thumbnail information across different JPEG standards for compatibility with legacy photo management software.
 * 4. When processing user‑uploaded photos in a C# backend and must add a 100×100 pixel thumbnail to satisfy third‑party APIs that read either the JFIF or EXIF thumbnail fields.
 * 5. When updating existing JPEG files with a new thumbnail after resizing, ensuring both JFIF and EXIF sections are synchronized to avoid mismatched previews.
 */
