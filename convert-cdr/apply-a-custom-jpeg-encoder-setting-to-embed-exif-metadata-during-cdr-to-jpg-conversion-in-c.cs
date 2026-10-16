// HOW-TO: Convert CDR to JPEG With EXIF Metadata And Custom Quality In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    CompressionType = JpegCompressionMode.Baseline
                };

                Aspose.Imaging.Exif.JpegExifData exifData = new Aspose.Imaging.Exif.JpegExifData
                {
                    ImageDescription = "Converted from CDR"
                };

                jpegOptions.ExifData = exifData;

                cdrImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to batch‑convert CorelDRAW files to JPEG for web publishing while preserving descriptive EXIF tags.
 * 2. When a photo‑management system requires JPEG images generated from CDR designs with a specific compression quality.
 * 3. When you must embed custom image description metadata into JPEGs created from vector drawings for catalog indexing.
 * 4. When automating a workflow that converts client‑provided CDR artwork to JPEG thumbnails with baseline JPEG compression.
 * 5. When integrating Aspose.Imaging into a C# application to produce JPEGs that include EXIF data for downstream GIS or digital asset tools.
 */
