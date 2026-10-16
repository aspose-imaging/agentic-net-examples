// HOW-TO: Extract JPEG EXIF Thumbnail and Save as Separate Image in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "thumbnail.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                var exif = jpegImage.ExifData;
                if (exif != null && exif.Thumbnail != null)
                {
                    using (var thumb = exif.Thumbnail)
                    {
                        thumb.Save(outputPath);
                    }
                }
                else
                {
                    Console.Error.WriteLine("No thumbnail found in EXIF data.");
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
 * 1. When you need to quickly generate a preview from a high‑resolution JPEG without re‑encoding the full image.
 * 2. When building a photo‑gallery app that displays thumbnails stored in the image’s EXIF data.
 * 3. When migrating legacy image archives and you must extract embedded thumbnails for cataloging or indexing.
 * 4. When creating a lightweight preview for mobile devices by reusing the original EXIF thumbnail instead of creating a new one.
 * 5. When validating that a JPEG file contains an EXIF thumbnail and saving it as a separate file for further analysis.
 */
