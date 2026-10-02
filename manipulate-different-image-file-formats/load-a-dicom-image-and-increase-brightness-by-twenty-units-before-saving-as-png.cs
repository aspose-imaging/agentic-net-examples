// HOW-TO: Increase DICOM Image Brightness by 20 and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.dcm";
        string outputPath = "Output\\image.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var dicom = (Aspose.Imaging.FileFormats.Dicom.DicomImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)dicom;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustBrightness(20);

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
 * 1. When a radiology software needs to enhance the visibility of a DICOM scan before exporting it as a PNG for reporting.
 * 2. When a medical research application must batch‑process DICOM files, increase their brightness, and store the results in a web‑friendly PNG format.
 * 3. When a hospital PACS integration requires converting DICOM images to PNG while applying a fixed brightness boost for display on low‑contrast monitors.
 * 4. When a C# desktop tool needs to load a DICOM image, cache its raster data, adjust brightness by a specific amount, and save the edited image for patient documentation.
 * 5. When a developer wants to use Aspose.Imaging to programmatically improve DICOM image contrast and generate PNG thumbnails for a mobile health app.
 */
