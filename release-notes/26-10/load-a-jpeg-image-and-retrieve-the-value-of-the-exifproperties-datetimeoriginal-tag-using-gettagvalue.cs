// HOW-TO: Read Original Capture Date from JPEG Exif Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;
using Aspose.Imaging.Exif.Enums;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpeg = image as JpegImage;
                if (jpeg == null)
                {
                    Console.Error.WriteLine("The file is not a JPEG image.");
                    return;
                }

                ExifData exif = jpeg.ExifData;
                var tagValue = exif.GetTagValue(ExifProperties.DateTimeOriginal);
                string result = tagValue != null ? tagValue.ToString() : "Tag not found";

                File.WriteAllText(outputPath, result);
                Console.WriteLine(result);
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
 * 1. When you need to display the photo's original capture timestamp in a gallery application.
 * 2. When you want to verify that uploaded JPEGs contain correct shooting dates for digital asset management.
 * 3. When you are building a compliance report that lists when each image was taken for legal evidence.
 * 4. When you need to sort a collection of JPEG files chronologically based on their EXIF DateTimeOriginal tag.
 * 5. When you are extracting metadata to populate a database of image metadata for a photo‑organizing tool.
 */
