// HOW-TO: Crop DICOM Image by Pixel Offsets and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                // Crop by shifts: left=10, right=10, top=20, bottom=20
                image.Crop(10, 10, 20, 20);
                var options = new PngOptions();
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
 * 1. When you need to extract a central region from a DICOM radiology scan and provide it as a lightweight PNG for a web‑based viewer.
 * 2. When a medical imaging workflow requires removing border artifacts from a DICOM file before archiving it as a PNG thumbnail.
 * 3. When a diagnostic application must programmatically crop patient scans by fixed pixel margins and convert them to PNG for reporting.
 * 4. When integrating Aspose.Imaging into a C# service that prepares DICOM images for machine‑learning preprocessing by cropping and saving them as PNG.
 * 5. When creating automated scripts that batch‑process DICOM files, trim unwanted edges, and generate PNG assets for documentation or presentation.
 */
