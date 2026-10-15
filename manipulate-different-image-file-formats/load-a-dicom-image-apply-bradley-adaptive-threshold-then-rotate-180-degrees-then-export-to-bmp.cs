// HOW-TO: Convert DICOM to BMP With Bradley Threshold And 180° Rotation In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.dcm";
            string outputPath = "Output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)dicom)
                {
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    // Apply Bradley Adaptive Threshold (windowSize: 15, brightnessDifference: 10)
                    raster.BinarizeBradley(10.0, 15);

                    // Rotate 180 degrees
                    raster.RotateFlip(RotateFlipType.Rotate180FlipNone);

                    // Save as BMP
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        raster.Save(outputPath, bmpOptions);
                    }
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
 * 1. When a medical imaging application needs to preprocess a DICOM scan by binarizing it with Bradley adaptive threshold, rotate it for correct orientation, and store the result as a BMP for legacy systems.
 * 2. When a radiology workflow requires converting DICOM images to a lossless BMP format after applying contrast‑enhancing thresholding and a 180° rotation to match the viewer’s coordinate system.
 * 3. When a diagnostic tool must generate a high‑contrast black‑and‑white BMP thumbnail from a DICOM file, applying Bradley thresholding and flipping the image upside down for patient‑specific display.
 * 4. When a healthcare integration project needs to automate the transformation of DICOM X‑ray images into BMP files after adaptive binarization and rotation to align with a non‑DICOM reporting platform.
 * 5. When a C# program processes DICOM images for machine‑learning preprocessing, using Bradley adaptive threshold to emphasize edges, rotating the image, and exporting to BMP for use in training pipelines.
 */
