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
        string inputPath = "input/corrupted.tif";
        string outputPath = "output/recovered.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            var loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath, loadOptions))
            {
                int index = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    Console.WriteLine($"Frame {index}: {frame.Width}x{frame.Height}");
                    index++;
                }

                tiff.Save(outputPath);
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
 * 1. When a batch of TIFF files from a scanner is damaged, you can use this code to automatically recover the images and continue processing them in a .NET application.
 * 2. If you need to extract and verify the dimensions of each frame in a multi‑page TIFF after a read error, the example shows how to load the file with Aspose.Imaging and enumerate its frames.
 * 3. When integrating a document management system that must handle partially corrupted TIFF archives, the second recovery mode (ConsistentRecover) ensures the maximum amount of usable data is restored.
 * 4. Developers building a photo‑archiving service can employ this snippet to salvage white‑background‑filled pixels for missing data while saving the repaired TIFF to a new location.
 * 5. In a diagnostic tool that reports on image integrity, the code demonstrates how to catch loading exceptions, list frame sizes, and save a cleaned‑up TIFF for further analysis.
 */
