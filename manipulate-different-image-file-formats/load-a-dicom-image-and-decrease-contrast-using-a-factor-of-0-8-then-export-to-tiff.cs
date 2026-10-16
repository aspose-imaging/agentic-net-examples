// HOW-TO: Load DICOM Image Reduce Contrast Save As TIFF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.dcm");
            string outputPath = Path.Combine("Output", "output.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage image = (DicomImage)Image.Load(inputPath))
            {
                image.AdjustContrast(0.8f);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a medical imaging application needs to lower the contrast of a DICOM scan before archiving it as a TIFF file.
 * 2. When converting radiology images to a format compatible with legacy picture archiving systems while adjusting visual intensity.
 * 3. When preprocessing DICOM data for machine‑learning pipelines that require TIFF inputs with standardized contrast.
 * 4. When generating print‑ready TIFF copies of DICOM studies with reduced contrast to improve readability on paper.
 * 5. When integrating Aspose.Imaging into a C# workflow that reads DICOM files, modifies their contrast, and stores the result as TIFF for downstream analysis.
 */
