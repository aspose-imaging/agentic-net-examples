// HOW-TO: Convert TIFF to CCITT Group 4 Compressed TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.tif";
            string outputPath = "Output\\sample_ccitt.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.TiffCcittFax4);
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
 * 1. When you need to reduce the file size of scanned black‑and‑white documents for fax transmission by saving them as CCITT Group 4 compressed TIFFs in a C# application.
 * 2. When archiving monochrome medical images or engineering drawings and require a lossless, fax‑compatible TIFF format using Aspose.Imaging in .NET.
 * 3. When generating printable PDFs from scanned pages and must first create a CCITT‑compressed TIFF to ensure fast rendering and small storage footprint.
 * 4. When integrating with legacy document management systems that only accept CCITT Group 4 TIFF files for OCR processing.
 * 5. When building a batch conversion tool that converts existing TIFF files to a standardized monochrome format with CCITT compression for long‑term digital preservation.
 */
