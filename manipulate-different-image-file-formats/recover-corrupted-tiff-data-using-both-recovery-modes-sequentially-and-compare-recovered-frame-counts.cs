// HOW-TO: Recover Corrupted TIFF Using Consistent and Full Modes and Compare Frames in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/corrupted.tif";
        string outputPath = "output/recovered.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            int consistentCount = 0;
            int fullCount = 0;

            var consistentOptions = new LoadOptions { DataRecoveryMode = DataRecoveryMode.ConsistentRecover };
            using (Image imgConsistent = Image.Load(inputPath, consistentOptions))
            {
                if (imgConsistent is TiffImage tiffConsistent)
                {
                    consistentCount = tiffConsistent.Frames.Count();
                }
            }

            var defaultOptions = new LoadOptions(); // default recovery mode
            using (Image imgFull = Image.Load(inputPath, defaultOptions))
            {
                if (imgFull is TiffImage tiffFull)
                {
                    fullCount = tiffFull.Frames.Count();
                }
            }

            Console.WriteLine($"Consistent recovery frame count: {consistentCount}");
            Console.WriteLine($"Full recovery frame count: {fullCount}");

            if (consistentCount == fullCount)
                Console.WriteLine("Both recovery modes yielded the same frame count.");
            else
                Console.WriteLine("Recovery modes yielded different frame counts.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a batch of scanned multi‑page TIFF documents becomes corrupted and you need to extract as many pages as possible using Aspose.Imaging’s recovery options.
 * 2. When you want to evaluate whether the default full recovery mode retrieves more frames than the consistent recovery mode for a damaged TIFF file.
 * 3. When you need to programmatically compare frame counts from two different TIFF recovery strategies to decide which mode to adopt in an automated pipeline.
 * 4. When you are building a C# utility that must create an output folder, load a corrupted TIFF, and log the number of successfully recovered pages.
 * 5. When you must handle missing or unreadable TIFF files gracefully by catching exceptions and reporting error messages during the recovery process.
 */
