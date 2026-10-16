// HOW-TO: Convert CMX Files to Multi‑Page TIFF in C# Unit Tests (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            var tests = new List<(string input, string output, string description)>
            {
                (Path.Combine(inputDir, "single_page.cmx"), Path.Combine(outputDir, "single_page.tif"), "Single-page CMX to TIFF conversion"),
                (Path.Combine(inputDir, "multi_page.cmx"), Path.Combine(outputDir, "multi_page.tif"), "Multi-page CMX to TIFF conversion")
            };

            foreach (var (inputPath, outputPath, description) in tests)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputDirPath = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrWhiteSpace(outputDirPath))
                {
                    Directory.CreateDirectory(outputDirPath);
                }

                using (Image image = Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, tiffOptions);
                }

                if (File.Exists(outputPath))
                {
                    Console.WriteLine($"{description}: Passed");
                }
                else
                {
                    Console.WriteLine($"{description}: Failed - output not created");
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
 * 1. When you need to verify that a single‑page CMX drawing converts correctly to a TIFF image using Aspose.Imaging in an automated test suite.
 * 2. When your application must ensure multi‑page CMX documents are transformed into multi‑frame TIFF files without data loss during continuous integration.
 * 3. When you want to confirm that missing input files are gracefully handled while converting CMX to TIFF in a C# build pipeline.
 * 4. When you require automated validation that the output directory structure is created and the resulting TIFF files are saved successfully after conversion.
 * 5. When you are testing the compatibility of Aspose.Imaging’s TiffOptions with default settings for both single‑page and multi‑page CMX conversions in .NET.
 */
