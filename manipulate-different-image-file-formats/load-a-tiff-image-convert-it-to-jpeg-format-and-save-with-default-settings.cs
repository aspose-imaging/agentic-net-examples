// HOW-TO: Convert TIFF Image to JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string? outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert scanned TIFF documents to smaller JPEG files for web display using C# and Aspose.Imaging.
 * 2. When a legacy system outputs TIFF images and you must generate JPEG thumbnails for a mobile app without custom compression settings.
 * 3. When integrating an image upload feature that accepts TIFF files but stores them as JPEG to save storage space in a .NET application.
 * 4. When automating a workflow that reads TIFF photos from a folder and saves them as JPEGs for compatibility with standard image viewers.
 * 5. When creating a simple conversion utility in C# that loads a TIFF and saves it as JPEG with default options for quick prototyping.
 */
