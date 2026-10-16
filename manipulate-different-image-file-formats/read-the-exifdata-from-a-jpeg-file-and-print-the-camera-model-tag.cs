// HOW-TO: Read EXIF Camera Model from JPEG using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                JpegImage jpegImage = image as JpegImage;
                if (jpegImage == null)
                {
                    Console.Error.WriteLine("The file is not a JPEG image.");
                    return;
                }

                var exif = jpegImage.ExifData;
                if (exif == null)
                {
                    Console.Error.WriteLine("No EXIF data found.");
                    return;
                }

                string cameraModel = exif.Model;
                Console.WriteLine($"Camera Model: {cameraModel}");
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
 * 1. When you need to display the camera model of uploaded JPEG photos in a web gallery using Aspose.Imaging for .NET.
 * 2. When you want to verify that JPEG images contain correct EXIF metadata before processing them in a batch job with C#.
 * 3. When building a photo‑organizing tool that groups pictures by the device that captured them by reading the Model tag.
 * 4. When extracting camera information to generate a report of equipment usage for a photography studio from JPEG files.
 * 5. When troubleshooting image files to ensure the JPEG contains EXIF data and the Model tag is readable in a .NET application.
 */
