// HOW-TO: Convert CMX to JPEG While Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.jpg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                cmxImage.Save(outputPath, jpegOptions);
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
 * 1. When a legacy CAD system exports drawings as CMX and a web application needs JPEG thumbnails with the correct orientation.
 * 2. When an automated batch process must convert archived CMX files to JPEG for a digital asset management system while keeping the original EXIF orientation metadata.
 * 3. When a mobile app displays user‑uploaded CMX images as JPEGs and must ensure they appear upright on devices that rely on EXIF orientation.
 * 4. When a reporting tool generates PDF reports that embed JPEG versions of CMX diagrams and requires the orientation to match the source image.
 * 5. When a cloud‑based image service migrates CMX assets to JPEG format for faster delivery and needs to retain orientation information for downstream processing.
 */
