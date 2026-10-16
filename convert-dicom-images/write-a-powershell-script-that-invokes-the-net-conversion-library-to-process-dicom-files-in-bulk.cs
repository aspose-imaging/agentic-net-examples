// HOW-TO: Bulk Convert DICOM Files to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

namespace DicomBulkConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputDicom";
                string outputDirectory = @"C:\OutputImages";

                // Ensure output base directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all DICOM files recursively
                string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm", SearchOption.AllDirectories);

                foreach (string inputPath in dicomFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (DicomImage image = (DicomImage)Image.Load(inputPath))
                    {
                        PngOptions pngOptions = new PngOptions();
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
 * 1. When a hospital needs to export thousands of DICOM scans to PNG for integration with a web‑based viewer.
 * 2. When a research lab wants to batch‑process MRI images into a lossless format for machine‑learning preprocessing.
 * 3. When a PACS administrator must generate thumbnail PNGs from archived DICOM files for quick visual indexing.
 * 4. When a medical imaging startup requires automated conversion of patient scans to PNG to embed them in PDF reports.
 * 5. When a developer builds a command‑line tool that recursively scans directories and converts all DICOM files to PNG for cross‑platform compatibility.
 */
