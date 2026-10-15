// HOW-TO: Load DICOM Image, Adjust Contrast, and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.dcm";
        string outputPath = "Output\\image.tiff";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            var loadOptions = new Aspose.Imaging.LoadOptions { BufferSizeHint = 100 };
            using (DicomImage dicom = (DicomImage)Aspose.Imaging.Image.Load(inputPath, loadOptions))
            {
                dicom.AdjustContrast(50);
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a medical imaging application needs to convert DICOM scans to TIFF for archival while improving visibility by increasing contrast.
 * 2. When a radiology workflow requires fast loading of large DICOM files using a memory buffer hint before exporting them to a widely supported TIFF format.
 * 3. When diagnostic software must preprocess DICOM images by adjusting contrast to enhance details and then save them as TIFF for downstream analysis tools.
 * 4. When a healthcare system wants to batch‑process DICOM images with Aspose.Imaging in C# and store the results as TIFF files with optimized memory usage.
 * 5. When a developer needs to programmatically read a DICOM file, apply a contrast boost, and output a TIFF for integration with non‑DICOM viewers.
 */
