// HOW-TO: Read JPEG EXIF Resolution and Save to Database in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "Database/record.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage jpeg = (JpegImage)Image.Load(inputPath))
            {
                var exif = jpeg.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found.");
                    return;
                }

                string xResolution = exif.XResolution?.ToString() ?? "0";
                string yResolution = exif.YResolution?.ToString() ?? "0";

                string record = $"{Path.GetFileName(inputPath)},{xResolution},{yResolution}";
                File.WriteAllText(outputPath, record);
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
 * 1. When you need to extract the DPI values from uploaded JPEG photos and store them alongside other metadata in a SQL or flat‑file database.
 * 2. When building a digital asset management system that records each image’s horizontal and vertical resolution for printing or scaling calculations.
 * 3. When validating image quality by reading EXIF resolution tags before processing large batches of pictures in a C# application.
 * 4. When migrating legacy image archives and you must capture original resolution information to preserve it in a new metadata repository.
 * 5. When generating reports that list image filenames with their XResolution and YResolution for compliance or auditing purposes.
 */
