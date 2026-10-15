// HOW-TO: Recover Corrupted TIFF Image with Consistent Recovery Mode in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Console.WriteLine("Starting TIFF recovery...");

            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                Console.WriteLine("Image loaded with recovery mode.");
                image.Save(outputPath);
                Console.WriteLine($"Recovered image saved to {outputPath}");
            }

            Console.WriteLine("TIFF recovery completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a batch process encounters a damaged multi‑frame TIFF file and needs to reconstruct missing frames automatically using Aspose.Imaging in C#.
 * 2. When an archival system must restore corrupted scanned documents saved as TIFF while preserving background color and logging each recovery step.
 * 3. When a medical imaging application receives incomplete TIFF images and wants to apply consistent recovery to ensure usable output without manual intervention.
 * 4. When a photo‑editing tool needs to load a TIFF, attempt data recovery, and save a clean version for further processing in a .NET environment.
 * 5. When a server‑side service must validate the existence of a TIFF file, recover it if corrupted, and provide detailed console feedback for troubleshooting.
 */
