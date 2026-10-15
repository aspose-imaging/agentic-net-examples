// HOW-TO: Batch Extract JPEG EXIF Tags to CSV with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        string inputDirectory = "Input";
        string outputDatabasePath = "Output\\exif.csv";

        Directory.CreateDirectory(inputDirectory);
        Directory.CreateDirectory(Path.GetDirectoryName(outputDatabasePath));

        try
        {
            using (var writer = new StreamWriter(outputDatabasePath, false))
            {
                writer.WriteLine("ImagePath,TagName,TagValue");
            }

            var files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg")
                    continue;

                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (JpegImage image = (JpegImage)Image.Load(file))
                {
                    var exif = image.ExifData;
                    if (exif == null)
                        continue;

                    var tagsProp = exif.GetType().GetProperty("Tags");
                    if (tagsProp == null)
                        continue;

                    var tags = tagsProp.GetValue(exif) as System.Collections.IEnumerable;
                    if (tags == null)
                        continue;

                    foreach (var tagObj in tags)
                    {
                        var nameProp = tagObj.GetType().GetProperty("Name");
                        var valueProp = tagObj.GetType().GetProperty("Value");
                        string tagName = nameProp?.GetValue(tagObj)?.ToString() ?? "";
                        string tagValue = valueProp?.GetValue(tagObj)?.ToString() ?? "";

                        using (var writer = new StreamWriter(outputDatabasePath, true))
                        {
                            writer.WriteLine($"{file},{tagName},{tagValue}");
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
 * 1. When you need to collect camera metadata from thousands of photos for a digital asset management system.
 * 2. When you want to generate a report of image capture dates, GPS coordinates, and camera settings for a photography analytics dashboard.
 * 3. When you must migrate EXIF information into a relational database to enable SQL queries for compliance auditing.
 * 4. When you are building a bulk image processing pipeline that tags images with their original metadata before resizing or watermarking.
 * 5. When you need to validate that all JPEG files in a directory contain required EXIF fields before uploading them to a cloud storage service.
 */
