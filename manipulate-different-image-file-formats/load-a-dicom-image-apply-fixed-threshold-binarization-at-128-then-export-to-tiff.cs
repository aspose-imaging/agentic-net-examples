// HOW-TO: Convert DICOM Image to Binary TIFF with Fixed Threshold in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.dcm");
            string outputPath = Path.Combine("Output", "output.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                RasterCachedImage rci = (RasterCachedImage)dicomImage;
                if (!rci.IsCached)
                {
                    rci.CacheData();
                }
                rci.BinarizeFixed(128);

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
 * 1. When a medical imaging application needs to create a high‑contrast black‑and‑white TIFF for archival or analysis from a DICOM scan.
 * 2. When a radiology workflow requires converting DICOM files to a TIFF format that legacy viewers can display without loss of diagnostic detail.
 * 3. When preprocessing DICOM images for OCR or pattern‑recognition algorithms that perform better on binary images with a fixed threshold.
 * 4. When generating printable reports that embed binary TIFFs derived from DICOM scans to reduce file size and improve visual clarity.
 * 5. When integrating DICOM data into a document management system that stores images as TIFF and requires a fixed‑threshold binarization step.
 */
