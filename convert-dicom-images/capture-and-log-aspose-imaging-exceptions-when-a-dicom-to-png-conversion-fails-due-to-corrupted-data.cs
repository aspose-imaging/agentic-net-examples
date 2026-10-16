// HOW-TO: Log Aspose Imaging Exceptions for DICOM to PNG Conversion in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a medical imaging application needs to convert DICOM scans to PNG thumbnails but must record errors if the DICOM file is corrupted.
 * 2. When integrating Aspose.Imaging into a batch processing pipeline that reads DICOM files from a folder and saves them as PNG while ensuring any failure is logged for later review.
 * 3. When building a diagnostic tool that validates incoming DICOM data and wants to capture detailed exception messages before aborting the conversion.
 * 4. When deploying a C# service that generates PNG previews of radiology images and requires graceful handling of missing or damaged files.
 * 5. When troubleshooting image conversion issues in a healthcare IT system and need to output error details to the console or a log file.
 */
