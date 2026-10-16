// HOW-TO: Resize CorelDRAW CDR to 1024x768 JPG While Saving in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.cdr";
        string outputPath = "Output\\sample.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate web‑ready JPEG thumbnails from CorelDRAW files without loading the full image into memory.
 * 2. When an e‑commerce platform requires product images converted from CDR to a fixed 1024×768 JPEG size for consistent display.
 * 3. When automating a batch job that converts legacy CDR artwork to JPEGs sized for email newsletters.
 * 4. When preparing print‑ready assets that must be down‑scaled to 1024×768 before uploading to a content management system.
 * 5. When integrating Aspose.Imaging into a C# application to resize and save CDR drawings as JPEGs for mobile app consumption.
 */
