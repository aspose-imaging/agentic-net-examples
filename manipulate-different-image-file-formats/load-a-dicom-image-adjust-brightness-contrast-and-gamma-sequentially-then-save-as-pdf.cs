// HOW-TO: Adjust Brightness Contrast Gamma of DICOM and Save as PDF in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.AdjustBrightness(50);
                image.AdjustContrast(20f);
                image.AdjustGamma(1.2f);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a medical imaging application needs to enhance a DICOM scan’s visibility before archiving it as a PDF report.
 * 2. When a radiology workflow requires batch processing to normalize brightness, contrast, and gamma of DICOM files for consistent print quality.
 * 3. When a healthcare web service must convert patient DICOM images to searchable PDF documents after applying visual adjustments.
 * 4. When a diagnostic tool wants to display clearer DICOM images on screens with varying lighting by programmatically tweaking image parameters and exporting to PDF.
 * 5. When a hospital’s document management system needs to store processed DICOM images as PDFs to integrate with non‑medical document viewers.
 */
