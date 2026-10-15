// HOW-TO: Batch Convert TIFF Files to WebP with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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

namespace BatchConvertTiffToWebP
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputTiff";
                string outputDirectory = @"C:\OutputWebP";

                Directory.CreateDirectory(outputDirectory);

                string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string filePath in files)
                {
                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    if (ext != ".tif" && ext != ".tiff")
                        continue;

                    string inputPath = filePath;
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (Image image = Image.Load(inputPath))
                    {
                        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);
                        string outputFileName = $"{baseName}_{timestamp}.webp";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        WebPOptions options = new WebPOptions();
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
 * 1. When you need to archive a large set of scanned TIFF documents as smaller WebP files while preserving the original order with unique timestamped names.
 * 2. When a web application must serve high‑quality images quickly, you can batch‑convert TIFF assets to WebP to reduce bandwidth and add timestamps for cache busting.
 * 3. When an automated nightly job has to transform newly uploaded TIFF images into WebP for a content‑management system and ensure each output file has a unique name.
 * 4. When a digital‑preservation workflow requires converting medical or satellite TIFF images to WebP for faster preview generation, using timestamps to track conversion time.
 * 5. When a developer builds a migration script that moves legacy TIFF files to a modern format and needs timestamped filenames to avoid overwriting existing WebP files.
 */
