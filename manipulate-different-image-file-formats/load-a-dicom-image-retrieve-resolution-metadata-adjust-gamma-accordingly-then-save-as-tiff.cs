// HOW-TO: Convert DICOM to TIFF with Gamma Adjustment Based on Resolution in C# (Aspose.Imaging for .NET)
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
            string outputPath = Path.Combine("Output", "result.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                double hRes = dicom.HorizontalResolution;
                double vRes = dicom.VerticalResolution;

                float gamma = 1.0f;
                if (vRes != 0)
                {
                    gamma = (float)(hRes / vRes);
                }

                if (dicom is RasterImage raster)
                {
                    raster.AdjustGamma(gamma);
                }

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicom.Save(outputPath, tiffOptions);
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
 * 1. When a radiology application needs to export DICOM scans to TIFF for archival while automatically correcting brightness based on the image’s horizontal and vertical resolution.
 * 2. When a medical imaging workflow requires converting patient DICOM images to a widely supported TIFF format and applying gamma correction to ensure consistent visual appearance across different viewers.
 * 3. When a developer wants to preprocess DICOM images for machine‑learning models by normalizing gamma using the resolution ratio before saving them as TIFF files.
 * 4. When a hospital’s reporting system must generate printable TIFF copies of DICOM studies and needs to adjust gamma so that printed images match the original diagnostic quality.
 * 5. When integrating Aspose.Imaging into a C# application to batch‑convert DICOM files to TIFF while preserving resolution metadata and applying automatic gamma adjustment for accurate display.
 */
