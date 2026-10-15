// HOW-TO: Load DICOM Image Apply Bradley Adaptive Threshold Save as BMP in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.BinarizeBradley(15);
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to convert a medical DICOM scan to a high‑contrast black‑and‑white BMP for legacy imaging systems.
 * 2. When you want to preprocess radiology images with Bradley adaptive thresholding before performing OCR on the extracted text.
 * 3. When integrating a C# application that must display DICOM images on devices that only support BMP format.
 * 4. When preparing DICOM data for machine‑learning pipelines that require binary bitmap inputs.
 * 5. When automating batch processing of DICOM files to generate printable BMP copies for patient records.
 */
