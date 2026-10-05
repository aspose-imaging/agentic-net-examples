// HOW-TO: Recover Corrupted TIFF Image with Consistent Recovery Mode in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\recovered.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a TIFF file is partially damaged and you need to reconstruct missing frames before further processing.
 * 2. When you must load a corrupted multi‑page TIFF in a .NET application and ensure the image can still be saved.
 * 3. When automating a batch job that cleans up broken TIFF archives by attempting consistent recovery.
 * 4. When integrating Aspose.Imaging into a document management system that receives imperfect TIFF scans from scanners.
 * 5. When troubleshooting image import errors and want to log failures while trying to salvage usable data from a TIFF.
 */
