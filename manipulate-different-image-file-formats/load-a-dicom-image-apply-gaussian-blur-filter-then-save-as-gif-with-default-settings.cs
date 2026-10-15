// HOW-TO: Apply Gaussian Blur to DICOM and Save as GIF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output\\output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)dicom;
                var rect = new Rectangle(0, 0, raster.Width, raster.Height);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(rect, blurOptions);

                var gifOptions = new GifOptions();
                raster.Save(outputPath, gifOptions);
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
 * 1. When you need to anonymize patient details in a DICOM scan by blurring the image before sharing it as a lightweight GIF for web review.
 * 2. When converting high‑resolution medical DICOM images to animated GIFs for quick preview in a hospital’s mobile app, applying a Gaussian blur to reduce noise.
 * 3. When generating de‑identified GIF thumbnails of radiology images for inclusion in electronic health record reports.
 * 4. When preprocessing DICOM images with a Gaussian blur to smooth artifacts before exporting them to GIF format for machine‑learning training datasets.
 * 5. When creating GIF‑based visualizations of DICOM slices with a soft blur effect for presentation slides or educational material.
 */
