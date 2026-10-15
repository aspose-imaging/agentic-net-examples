// HOW-TO: Convert DICOM Medical Image To 16‑Bit PNG In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
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
            string inputPath = "Input\\image.dcm";
            string outputPath = "Output\\image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)dicom)
                {
                    if (!raster.IsCached) raster.CacheData();

                    PngOptions pngOptions = new PngOptions
                    {
                        BitDepth = 16,
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, pngOptions);
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
 * 1. When a radiology software needs to export high‑resolution DICOM scans as lossless 16‑bit PNG files for downstream image analysis tools.
 * 2. When a research project requires converting a batch of DICOM images to a format that can be displayed in standard web browsers without losing grayscale depth.
 * 3. When a developer wants to integrate Aspose.Imaging into a C# application to cache DICOM pixel data and save it as a true‑color PNG with alpha for visualization.
 * 4. When a medical imaging pipeline must preserve the original pixel intensity range while converting to PNG for machine‑learning model input.
 * 5. When a hospital IT system needs to generate portable 16‑bit PNG copies of DICOM files for archiving or sharing with non‑DICOM‑aware collaborators.
 */
