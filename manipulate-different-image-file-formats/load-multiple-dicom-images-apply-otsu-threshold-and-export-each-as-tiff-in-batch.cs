// HOW-TO: Batch Convert DICOM Images to TIFF with Otsu Threshold in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                {
                    RasterCachedImage raster = (RasterCachedImage)dicom;
                    if (!raster.IsCached)
                        raster.CacheData();

                    raster.BinarizeOtsu();

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height))
                    {
                        tiff.SavePixels(tiff.Bounds, raster.LoadPixels(raster.Bounds));

                        string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        tiff.Save(outputPath);
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
 * 1. When a radiology software needs to preprocess a folder of DICOM scans by binarizing them with Otsu’s method and saving the results as TIFF files for downstream analysis.
 * 2. When a research team wants to automate the conversion of large sets of medical images into a lossless format while applying consistent thresholding for image segmentation.
 * 3. When a health‑IT system must generate printable TIFF copies of DICOM images after applying Otsu threshold to highlight regions of interest.
 * 4. When a developer is building a batch pipeline that reads DICOM files from a directory, caches the pixel data, performs binary conversion, and stores each output as a separate TIFF file.
 * 5. When an AI training workflow requires fast creation of binary TIFF masks from raw DICOM datasets to feed into a machine‑learning model.
 */
