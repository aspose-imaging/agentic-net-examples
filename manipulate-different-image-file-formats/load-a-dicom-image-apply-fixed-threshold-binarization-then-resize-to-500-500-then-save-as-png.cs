// HOW-TO: Convert DICOM to PNG with Fixed Threshold Binarization and Resize in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.BinarizeFixed(128);
                image.Resize(500, 500);
                PngOptions options = new PngOptions();
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
 * 1. When a medical imaging application needs to create high‑contrast PNG thumbnails from DICOM scans for quick preview in a web portal.
 * 2. When a radiology workflow requires converting DICOM files to binary PNG images for OCR or pattern‑recognition preprocessing.
 * 3. When a healthcare archive system must downsize large DICOM images to a fixed 500×500 size and store them as lossless PNGs for efficient storage.
 * 4. When a diagnostic tool wants to apply a fixed threshold to highlight bone structures before exporting the result as a PNG for reporting.
 * 5. When a developer integrates Aspose.Imaging into a C# service that transforms DICOM scans into standardized PNG assets for cross‑platform viewing.
 */
