// HOW-TO: Batch Convert All TIFF Files in a Folder to WebP Using C# (Aspose.Imaging for .NET)
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
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputFolder = @"C:\Images\TiffInput";
                string outputFolder = @"C:\Images\WebpOutput";

                // Ensure output directory exists
                Directory.CreateDirectory(outputFolder);

                // Get all TIFF files in the input folder
                string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");
                string[] tiffFilesUpper = Directory.GetFiles(inputFolder, "*.tiff");
                string[] allTiffFiles = new string[tiffFiles.Length + tiffFilesUpper.Length];
                tiffFiles.CopyTo(allTiffFiles, 0);
                tiffFilesUpper.CopyTo(allTiffFiles, tiffFiles.Length);

                foreach (string inputPath in allTiffFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the TIFF image and save as WebP
                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new WebPOptions();
                        image.Save(outputPath, options);
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
 * 1. When you need to reduce storage size of a large collection of scanned TIFF documents by converting them to the more compact WebP format in a .NET application.
 * 2. When you want to automate the preparation of TIFF images for web delivery, converting every file in a directory to WebP with a single C# script.
 * 3. When a photo‑processing pipeline must replace legacy TIFF assets with WebP thumbnails for faster loading on browsers, using a foreach loop to handle each file.
 * 4. When you are migrating an archive of medical or engineering diagrams from TIFF to WebP and require a reliable batch conversion that preserves image data in .NET.
 * 5. When you need to integrate bulk image format conversion into a Windows service or console tool that watches a folder and outputs WebP files for downstream processing.
 */
