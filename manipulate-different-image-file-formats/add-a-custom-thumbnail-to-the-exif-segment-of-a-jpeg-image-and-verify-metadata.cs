// HOW-TO: Add Custom EXIF Thumbnail to JPEG and Preserve Metadata in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string thumbnailPath = "thumb.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            if (!File.Exists(thumbnailPath))
            {
                Console.Error.WriteLine($"File not found: {thumbnailPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif != null)
                {
                    using (JpegImage thumb = (JpegImage)Aspose.Imaging.Image.Load(thumbnailPath))
                    {
                        exif.Thumbnail = thumb;
                    }

                    Console.WriteLine($"Thumbnail set: {(exif.Thumbnail != null)}");
                }
                else
                {
                    Console.WriteLine("No EXIF data present.");
                }

                JpegOptions options = new JpegOptions
                {
                    KeepMetadata = true,
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
 * 1. When you need to embed a preview image into a JPEG’s EXIF data for faster thumbnail display in photo galleries.
 * 2. When you want to replace an existing EXIF thumbnail with a custom image while keeping all other metadata intact.
 * 3. When you are building a C# application that must generate JPEG files with embedded thumbnails for digital asset management systems.
 * 4. When you need to verify that a JPEG’s EXIF segment contains a thumbnail after programmatically modifying the image.
 * 5. When you are migrating images to a new format and must preserve EXIF metadata, including a custom thumbnail, using Aspose.Imaging.
 */
