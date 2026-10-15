// HOW-TO: Batch Adjust Brightness of DICOM Images and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\DicomInput";
            string outputFolder = @"C:\DicomOutput";

            // Get all DICOM files in the input folder
            string[] dicomFiles = Directory.GetFiles(inputFolder, "*.dcm");

            foreach (string inputPath in dicomFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DICOM image
                using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
                {
                    // Adjust brightness by +10 units
                    dicomImage.AdjustBrightness(10);

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    PngOptions pngOptions = new PngOptions();
                    dicomImage.Save(outputPath, pngOptions);
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
 * 1. When a radiology application needs to increase the brightness of many DICOM scans before converting them to PNG for easier viewing on standard monitors.
 * 2. When a medical research project requires preprocessing of DICOM files to enhance visibility and then export them as PNG for inclusion in publications.
 * 3. When a healthcare IT system must automatically adjust image brightness and generate web‑friendly PNG thumbnails for patient portals.
 * 4. When a machine‑learning pipeline needs uniformly brightened DICOM images saved as PNG to feed into a model that only accepts common image formats.
 * 5. When an archival workflow has to batch‑process DICOM files, apply a brightness correction, and store the results as PNG files for long‑term storage outside the DICOM ecosystem.
 */
