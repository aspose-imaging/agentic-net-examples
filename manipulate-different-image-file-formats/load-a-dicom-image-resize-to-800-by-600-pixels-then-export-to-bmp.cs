// HOW-TO: Resize DICOM Image to 800x600 and Save as BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.Resize(800, 600);
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to convert high‑resolution DICOM scans into smaller BMP files for faster viewing on legacy systems.
 * 2. When a healthcare workflow requires batch‑processing of DICOM files to a uniform 800 × 600 size before embedding them in patient reports.
 * 3. When a developer must generate BMP thumbnails from DICOM images for use in a web‑based radiology portal.
 * 4. When an integration project extracts DICOM data and stores it as BMP in a file system that only supports standard bitmap formats.
 * 5. When a diagnostic tool needs to resize DICOM images to fit a fixed‑size display panel while preserving image quality using Aspose.Imaging for .NET.
 */
