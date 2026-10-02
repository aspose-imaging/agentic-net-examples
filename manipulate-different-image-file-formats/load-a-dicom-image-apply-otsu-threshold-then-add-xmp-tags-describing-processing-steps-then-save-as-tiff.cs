// HOW-TO: Convert DICOM to TIFF with Otsu Binarization in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.dcm";
            string outputPath = "Output\\processed.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                RasterCachedImage raster = (RasterCachedImage)dicom;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.BinarizeOtsu();

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF files for archival while applying Otsu threshold to create binary images.
 * 2. When a radiology workflow requires automated preprocessing of DICOM images to highlight regions of interest before further analysis.
 * 3. When a .NET service must generate high‑contrast black‑and‑white TIFFs from DICOM data for compatibility with legacy imaging software.
 * 4. When a batch processing tool needs to read DICOM files, perform Otsu binarization, and store the results as TIFFs for downstream machine‑learning pipelines.
 * 5. When a developer wants to ensure DICOM pixel data is cached, thresholded, and saved in a widely supported format without manual image conversion steps.
 */
