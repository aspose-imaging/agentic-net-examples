// HOW-TO: Convert DICOM to PDF with Gaussian Blur and Brightness Adjustment in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions());
                image.AdjustBrightness(15);
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a healthcare application needs to embed a cleaned‑up DICOM scan into a patient PDF report, applying blur to reduce noise and increasing brightness for better visibility.
 * 2. When a radiology workflow requires batch conversion of DICOM images to PDFs while automatically enhancing contrast and smoothing details before archiving.
 * 3. When a medical imaging viewer wants to export a single DICOM slice as a PDF document with pre‑processed visual adjustments for presentation to clinicians.
 * 4. When a hospital information system must generate printable PDFs from DICOM files, using Gaussian blur to mask sensitive details and brightness correction to meet readability standards.
 * 5. When a developer builds a C# utility that transforms diagnostic DICOM images into PDF format with built‑in image filtering and brightness tuning using Aspose.Imaging.
 */
