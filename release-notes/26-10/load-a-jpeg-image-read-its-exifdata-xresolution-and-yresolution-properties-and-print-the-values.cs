// HOW-TO: Read JPEG Exif XResolution and YResolution Values in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                ExifData exif = image.ExifData;
                var xResolution = exif.XResolution;
                var yResolution = exif.YResolution;

                Console.WriteLine($"XResolution: {xResolution}");
                Console.WriteLine($"YResolution: {yResolution}");
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
 * 1. When you need to verify the DPI (dots per inch) settings of a JPEG before printing it.
 * 2. When you want to extract the image resolution metadata to correctly scale photos in a web gallery.
 * 3. When you are building a validation tool that checks uploaded JPEGs for required X/Y resolution values.
 * 4. When you need to log or display the original camera resolution for digital asset management purposes.
 * 5. When you are converting images and must compare or preserve the XResolution and YResolution EXIF data.
 */
