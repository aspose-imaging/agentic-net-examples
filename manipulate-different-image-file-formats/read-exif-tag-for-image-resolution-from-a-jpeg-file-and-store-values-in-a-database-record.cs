// HOW-TO: Read JPEG EXIF Resolution and Save to CSV with C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
            string dbPath = "output/database.csv";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                double xRes = 0;
                double yRes = 0;

                if (exif != null)
                {
                    if (exif.XResolution != null)
                        xRes = exif.XResolution.Value;
                    if (exif.YResolution != null)
                        yRes = exif.YResolution.Value;
                }

                bool fileExists = File.Exists(dbPath);
                using (var writer = new StreamWriter(dbPath, true))
                {
                    if (!fileExists)
                    {
                        writer.WriteLine("FileName,XResolution,YResolution");
                    }
                    writer.WriteLine($"{Path.GetFileName(inputPath)},{xRes},{yRes}");
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
 * 1. When you need to catalog a collection of photos by their DPI values for printing workflows, you can extract the XResolution and YResolution EXIF tags from each JPEG and record them in a CSV database using C#.
 * 2. When building a digital asset management system that sorts images based on their native resolution, reading the EXIF resolution from JPEG files and storing the values in a database enables efficient queries.
 * 3. When generating reports for a photography studio that require the exact image resolution metadata, this code reads the JPEG EXIF data and appends the results to a CSV file for further analysis.
 * 4. When migrating image metadata into a legacy system that only accepts CSV imports, extracting JPEG EXIF resolution tags with Aspose.Imaging and writing them to a CSV provides a simple integration path.
 * 5. When validating that uploaded JPEGs meet minimum resolution requirements before processing, you can read the EXIF XResolution/YResolution values and log them to a database for audit purposes.
 */
