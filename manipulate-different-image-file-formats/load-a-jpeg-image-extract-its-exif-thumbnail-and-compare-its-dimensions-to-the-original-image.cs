// HOW-TO: Extract JPEG EXIF Thumbnail and Compare Its Size to Original in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        string inputPath = "input.jpg";
        string outputPath = "thumbnail.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                Console.WriteLine($"Original image dimensions: {originalWidth}x{originalHeight}");

                ExifData exif = image.ExifData;
                if (exif == null || exif.Thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail found.");
                    return;
                }

                using (Image thumbnail = exif.Thumbnail)
                {
                    int thumbWidth = thumbnail.Width;
                    int thumbHeight = thumbnail.Height;
                    Console.WriteLine($"EXIF thumbnail dimensions: {thumbWidth}x{thumbHeight}");

                    thumbnail.Save(outputPath);
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
 * 1. When you need to retrieve the embedded thumbnail from a JPEG photo to display a quick preview without loading the full‑size image.
 * 2. When you want to verify that the EXIF thumbnail dimensions match or differ from the original image for quality‑control or metadata validation.
 * 3. When you are building a photo‑gallery application that stores or serves the thumbnail separately to reduce bandwidth.
 * 4. When you need to save the EXIF thumbnail as a standalone file for archival or further processing in C#.
 * 5. When you are debugging or auditing image metadata and need to log both the original and thumbnail resolutions.
 */
