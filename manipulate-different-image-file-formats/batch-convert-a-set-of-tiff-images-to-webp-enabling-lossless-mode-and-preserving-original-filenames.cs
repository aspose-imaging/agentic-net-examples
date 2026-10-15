// HOW-TO: Batch Convert TIFF Images to Lossless WebP in C# (Aspose.Imaging for .NET)
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

namespace BatchTiffToWebp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\Images\Input";
                string outputDirectory = @"C:\Images\Output";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all TIFF files in the input directory
                string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string filePath in tiffFiles)
                {
                    string extension = Path.GetExtension(filePath).ToLowerInvariant();
                    if (extension != ".tif" && extension != ".tiff")
                        continue;

                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".webp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the TIFF image
                    using (Image image = Image.Load(filePath))
                    {
                        // Set WebP options for lossless compression
                        WebPOptions options = new WebPOptions
                        {
                            Lossless = true
                        };

                        // Save as WebP
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {filePath} -> {outputPath}");
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
 * 1. When you need to compress a large collection of high‑resolution TIFF scans into smaller lossless WebP files for faster web loading while keeping the original file names.
 * 2. When you are building an automated pipeline that converts medical or satellite TIFF images to WebP to reduce storage costs without sacrificing image fidelity.
 * 3. When a desktop application must export user‑uploaded TIFF photos to WebP format for cross‑platform compatibility while preserving the original naming scheme.
 * 4. When migrating a legacy image archive from TIFF to a modern web‑friendly format and you require a C# script that processes all files in a folder in one go.
 * 5. When creating a batch image‑conversion tool that integrates Aspose.Imaging to generate lossless WebP thumbnails from TIFF assets for e‑commerce product catalogs.
 */
