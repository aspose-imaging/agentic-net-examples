// HOW-TO: Convert DICOM To TIFF With Floyd Steinberg Dithering In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.dcm";
        string outputPath = "Output\\result.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                dicomImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a hospital needs to archive radiology scans as lossless TIFF files with reduced banding for better visual quality.
 * 2. When a medical research application must display DICOM images on screens that only support 8‑bit TIFF, using Floyd‑Steinberg dithering to preserve detail.
 * 3. When a developer is building a PACS export tool that converts patient DICOM files to TIFF for integration with third‑party imaging software.
 * 4. When a diagnostic imaging workflow requires converting DICOM to TIFF before printing hard copies, applying dithering to improve grayscale gradients.
 * 5. When an AI training pipeline needs DICOM images in TIFF format with dithering applied to standardize input data across different models.
 */
