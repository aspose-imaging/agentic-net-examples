// HOW-TO: Batch Convert Multiple TIFF Files to WebP with Quality 90 in C# (Aspose.Imaging for .NET)
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

namespace ImageBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded list of input TIFF files
                string[] inputPaths = new string[]
                {
                    "input1.tif",
                    "input2.tif",
                    "input3.tif"
                };

                // Hardcoded output directory
                string outputDirectory = "output";

                foreach (string inputPath in inputPaths)
                {
                    // Input file existence check
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load TIFF image and save as WebP with quality 90
                    using (Image image = Image.Load(inputPath))
                    {
                        var webpOptions = new WebPOptions
                        {
                            Quality = 90
                        };
                        image.Save(outputPath, webpOptions);
                    }

                    // Log successful conversion
                    Console.WriteLine($"Converted {inputPath} to {outputPath}");
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
 * 1. When you need to reduce the storage size of scanned documents by converting TIFF scans to WebP while preserving high visual quality.
 * 2. When you want to automate the conversion of a predefined list of TIFF images to WebP for faster web publishing.
 * 3. When you must ensure an output folder is created automatically and log each successful image conversion in a .NET application.
 * 4. When you need to process a batch of images with a specific compression quality setting to meet performance or bandwidth requirements.
 * 5. When you require robust error handling for missing source files while converting TIFF to WebP in a C# console tool.
 */
