// HOW-TO: Batch Convert DICOM Files to PNG While Preserving Filenames in C# (Aspose.Imaging for .NET)
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

namespace DicomBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\DICOMInput";
                string outputDirectory = @"C:\PNGOutput";

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all DICOM files in the input directory
                string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm", SearchOption.TopDirectoryOnly);

                foreach (string inputPath in dicomFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Prepare output path preserving original filename
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load DICOM image and save as PNG
                    using (Image image = Image.Load(inputPath))
                    {
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital needs to export a folder of DICOM scans to PNG for quick viewing in web browsers.
 * 2. When a research lab wants to create thumbnail PNG images from a batch of DICOM files for inclusion in a publication.
 * 3. When a medical imaging system must archive DICOM studies as lossless PNG files while keeping the original study identifiers in the filenames.
 * 4. When a developer integrates Aspose.Imaging into a C# application to automate conversion of incoming DICOM images to PNG for downstream AI analysis.
 * 5. When a radiology department requires a script to convert daily DICOM uploads to PNG without altering the original file names for easy cross‑reference.
 */
