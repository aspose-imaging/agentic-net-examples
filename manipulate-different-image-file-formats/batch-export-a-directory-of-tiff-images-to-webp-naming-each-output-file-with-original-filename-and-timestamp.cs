// HOW-TO: Batch Convert TIFF Files to WebP with Timestamped Names in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchTiffToWebP
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDir = @"C:\InputTiff";
                string outputDir = @"C:\OutputWebP";

                // Ensure base output directory exists
                Directory.CreateDirectory(outputDir);

                string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");
                string[] tiffFilesAlt = Directory.GetFiles(inputDir, "*.tiff");
                var allFiles = tiffFiles.Concat(tiffFilesAlt).ToArray();

                foreach (var inputPath in allFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new WebPOptions();
                        image.Save(outputPath, options);
                    }
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
 * 1. When you need to migrate a large collection of high‑resolution TIFF scans to the smaller WebP format for web delivery while preserving the original filenames with a processing timestamp.
 * 2. When an automated nightly job must convert newly added TIFF assets in a folder to WebP and store them with unique names to avoid overwriting previous exports.
 * 3. When you want to create timestamped WebP thumbnails from archival TIFF documents for version‑controlled content management systems.
 * 4. When a digital asset pipeline requires batch conversion of TIFF medical images to WebP for faster loading in browser‑based viewers, with each file uniquely identified by a timestamp.
 * 5. When you are building a C# utility that processes a directory of TIFF files, saves them as WebP, and ensures the output directory structure exists before writing each file.
 */
