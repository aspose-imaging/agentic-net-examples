// HOW-TO: Read All EXIF Tags from a JPEG and Display in Console C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exifData = image.ExifData;
                if (exifData == null)
                {
                    Console.WriteLine("No EXIF data found.");
                    return;
                }

                var properties = exifData.GetType().GetProperties();
                Console.WriteLine("{0,-30} {1}", "Tag", "Value");
                Console.WriteLine(new string('-', 50));
                foreach (var prop in properties)
                {
                    try
                    {
                        var value = prop.GetValue(exifData);
                        Console.WriteLine("{0,-30} {1}", prop.Name, value ?? "null");
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Error reading tag {prop.Name}: {ex.Message}");
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
 * 1. When you need to verify camera settings such as aperture or ISO stored in a JPEG before processing the image in a C# application.
 * 2. When building a diagnostic tool that lists all metadata of user‑uploaded photos to ensure compliance with privacy policies.
 * 3. When creating a batch script that logs EXIF information from a collection of images for archival or cataloging purposes.
 * 4. When troubleshooting image conversion issues by comparing original EXIF values with those after transformation using Aspose.Imaging.
 * 5. When developing a console utility that extracts and displays JPEG metadata to help photographers quickly review shooting details.
 */
