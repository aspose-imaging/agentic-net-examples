// HOW-TO: Recover Corrupted TIFF Using Consistent Recovery Mode in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input/corrupted.tif";
            string outputPath = "output/recovered.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (TiffImage image = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                image.Save(outputPath);
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
 * 1. When a batch of scanned documents saved as TIFF files become partially corrupted and need automatic recovery before archiving.
 * 2. When an application must load a damaged TIFF image, fix it, and then apply further image processing like OCR or watermarking.
 * 3. When a server receives uploaded TIFF images that may be incomplete, and you need to restore them to a consistent state for downstream workflows.
 * 4. When migrating legacy TIFF archives to a new system and you must ensure each file is readable by using Aspose.Imaging’s recovery options.
 * 5. When developing a diagnostic tool that validates TIFF integrity and automatically rewrites corrupted files with a white background for visual consistency.
 */
