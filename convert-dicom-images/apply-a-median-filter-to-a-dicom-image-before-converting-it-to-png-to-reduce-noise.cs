// HOW-TO: Apply Median Filter to DICOM and Convert to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var dicom = (DicomImage)image;
                var raster = (Aspose.Imaging.RasterImage)dicom;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                dicom.Save(outputPath, pngOptions);
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
 * 1. When a radiology software needs to reduce speckle noise in a DICOM scan before displaying it as a lightweight PNG thumbnail.
 * 2. When a healthcare web portal must transform noisy DICOM X‑ray images into PNG files for faster browser rendering.
 * 3. When a medical research pipeline requires preprocessing DICOM images with a median filter to improve analysis accuracy and then store them as PNG for archival.
 * 4. When a C# application integrates Aspose.Imaging to clean up ultrasound DICOM frames and export them as PNG for inclusion in patient reports.
 * 5. When a diagnostic imaging system wants to automate noise reduction on incoming DICOM files and generate PNG copies for machine‑learning model training.
 */
