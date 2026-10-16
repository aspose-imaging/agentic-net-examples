// HOW-TO: Convert Grayscale DICOM to PNG with Truecolor and Alpha in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Dicom;
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

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)dicom;
                raster.Grayscale();

                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to display DICOM scans on web browsers that only support PNG, developers can convert the grayscale DICOM to a PNG with truecolor and alpha.
 * 2. When integrating DICOM images into a reporting system that requires lossless PNG files, developers can use this code to generate high‑quality PNGs while preserving grayscale data.
 * 3. When building a cross‑platform viewer that loads images from a file system, developers can convert DICOM files to PNG to leverage standard image libraries.
 * 4. When automating batch processing of radiology images for archival, developers can convert each DICOM to PNG with consistent color settings for easier indexing.
 * 5. When creating thumbnails for a PACS dashboard, developers can quickly render grayscale DICOM images as PNGs with alpha transparency for overlay effects.
 */
