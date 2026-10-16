// HOW-TO: Batch Convert DNG Images to JPEG with 85 Quality in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Get all DNG files in the input directory
            string[] dngFiles = Directory.GetFiles(inputDirectory, "*.dng");

            foreach (string inputPath in dngFiles)
            {
                // Check if the file exists (redundant due to GetFiles, but follows the rule)
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DNG image
                using (DngImage dngImage = (DngImage)Image.Load(inputPath))
                {
                    // Set JPEG options with quality 85
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };

                    // Save as JPEG
                    dngImage.Save(outputPath, jpegOptions);
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

/*
 * Real-World Use Cases:
 * 1. When a photographer needs to quickly generate web‑ready JPEG previews from a folder of raw DNG files using C#.
 * 2. When an e‑commerce platform must reduce storage costs by converting high‑resolution DNG product photos to compressed JPEGs at a specific quality level.
 * 3. When a digital asset management system automates nightly processing to transform newly uploaded DNG assets into JPEG thumbnails for faster browsing.
 * 4. When a mobile app backend prepares user‑submitted raw images for display by batch converting DNGs to JPEGs with consistent 85 % quality.
 * 5. When a scientific imaging workflow requires exporting raw camera captures (DNG) to JPEG for inclusion in reports while preserving visual fidelity.
 */
