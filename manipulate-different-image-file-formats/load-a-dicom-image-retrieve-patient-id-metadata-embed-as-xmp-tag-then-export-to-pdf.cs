// HOW-TO: Convert DICOM Image to PDF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
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
 * 1. When a healthcare application must generate a printable PDF report from a DICOM scan for doctors to review.
 * 2. When a medical imaging workflow needs to archive DICOM files as PDF documents to integrate with a document management system.
 * 3. When a radiology web service wants to provide patients with a downloadable PDF version of their imaging study.
 * 4. When a hospital’s billing software requires converting DICOM images to PDF to attach them to invoices.
 * 5. When a research tool needs to batch‑process DICOM images and save them as PDFs for inclusion in scientific publications.
 */
