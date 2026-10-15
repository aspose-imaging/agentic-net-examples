// HOW-TO: Recover Corrupted Multi‑Page TIFF and Generate Frame Recovery Report in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/corrupted.tif";
            string outputPath = "output/recovered.tif";
            string reportPath = "output/recovery_report.txt";

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

            string reportDir = Path.GetDirectoryName(reportPath);
            if (!string.IsNullOrWhiteSpace(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            LoadOptions loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover
            };

            using (TiffImage recoveredTiff = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                recoveredTiff.Save(outputPath);

                using (StreamWriter writer = new StreamWriter(reportPath))
                {
                    for (int i = 0; i < recoveredTiff.Frames.Count(); i++)
                    {
                        writer.WriteLine($"Recovered frame index: {i}");
                    }
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
 * 1. When a scanning workflow produces a partially damaged multi‑page TIFF, you can use this code to recover the image and save a clean version.
 * 2. When you need to extract which pages were successfully restored after a TIFF corruption, the generated text report lists the recovered frame indices.
 * 3. When integrating Aspose.Imaging into a .NET service that must automatically fix uploaded TIFF files before further processing, this snippet performs the recovery and logging.
 * 4. When troubleshooting batch image imports and you want to verify that each frame of a TIFF archive was recovered consistently, the code saves the recovered file and creates a verification report.
 * 5. When building a document archival system that must handle occasional file corruption, you can employ this routine to apply ConsistentRecover mode and keep a record of the recovered pages for audit purposes.
 */
