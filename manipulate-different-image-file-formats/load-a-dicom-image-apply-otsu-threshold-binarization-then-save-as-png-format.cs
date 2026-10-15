// HOW-TO: Convert DICOM to PNG with Otsu Threshold Binarization in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.BinarizeOtsu();
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to extract binary masks from DICOM scans for further analysis, developers can load the DICOM file, apply Otsu binarization, and export the result as a PNG.
 * 2. When integrating a radiology workflow that requires converting DICOM X‑ray images to a web‑friendly format while preserving high‑contrast details, this code provides an automated C# solution.
 * 3. When building a diagnostic reporting tool that highlights regions of interest by thresholding DICOM images and storing them as lossless PNG files for inclusion in PDFs, the snippet performs the necessary steps.
 * 4. When a research project needs to preprocess a batch of DICOM images into binary PNGs for machine‑learning segmentation models, developers can reuse this code to standardize the conversion.
 * 5. When a hospital’s PACS system needs a quick C# utility to generate thumbnail PNGs with Otsu‑based binarization for fast preview in a web portal, this example demonstrates the required process.
 */
