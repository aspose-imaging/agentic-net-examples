// HOW-TO: Update Artist EXIF Tag In Multiple JPEG Files Using C# (Aspose.Imaging for .NET)
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
        string inputDirectory = "InputImages";

        try
        {
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");

            foreach (string inputPath in jpgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    if (image.ExifData != null)
                    {
                        image.ExifData.Artist = "New Artist";
                    }

                    string outputDir = Path.GetDirectoryName(inputPath);
                    Directory.CreateDirectory(outputDir);
                    image.Save(inputPath);
                }
            }

            foreach (string inputPath in jpegFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(inputPath))
                {
                    if (image.ExifData != null)
                    {
                        image.ExifData.Artist = "New Artist";
                    }

                    string outputDir = Path.GetDirectoryName(inputPath);
                    Directory.CreateDirectory(outputDir);
                    image.Save(inputPath);
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
 * 1. When you need to assign or correct the photographer’s name across a large collection of JPEG photos before publishing them online.
 * 2. When a digital asset management system requires consistent Artist metadata in JPEG images for proper attribution and search indexing.
 * 3. When preparing a batch of product photos for an e‑commerce site and you must embed the brand’s artist information into each file’s EXIF data.
 * 4. When migrating legacy images to a new workflow and you need to update the EXIF Artist tag in place without creating duplicate files.
 * 5. When automating compliance with copyright standards by programmatically setting the Artist field in all JPEG files using C# and Aspose.Imaging.
 */
