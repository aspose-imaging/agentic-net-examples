// HOW-TO: Report Progress While Converting DICOM Files to PNG in C# (Aspose.Imaging for .NET)
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
                string inputDirectory = "InputDicom";
                string outputDirectory = "OutputPng";

                // Get all DICOM files in the input directory
                string[] dicomFiles = Directory.GetFiles(inputDirectory, "*.dcm");
                int totalFiles = dicomFiles.Length;

                // Progress reporter
                IProgress<int> progress = new Progress<int>(percent =>
                {
                    Console.WriteLine($"Progress: {percent}%");
                });

                for (int i = 0; i < totalFiles; i++)
                {
                    string inputPath = dicomFiles[i];
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    ConvertDicomToPng(inputPath, outputPath);

                    int percentComplete = (int)(((i + 1) / (double)totalFiles) * 100);
                    progress.Report(percentComplete);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertDicomToPng(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a radiology software needs to batch‑convert thousands of DICOM scans to PNG for web preview while showing users a percentage complete.
 * 2. When a medical research pipeline processes DICOM images on a server and wants to log conversion progress to monitor performance.
 * 3. When a desktop application lets clinicians select a folder of DICOM files and displays real‑time progress as each image is saved as PNG.
 * 4. When an automated build script converts DICOM assets to PNG for documentation and needs a simple progress callback to detect stalls.
 * 5. When a cloud service ingests DICOM uploads, converts them to PNG thumbnails, and reports conversion status back to the client UI.
 */
