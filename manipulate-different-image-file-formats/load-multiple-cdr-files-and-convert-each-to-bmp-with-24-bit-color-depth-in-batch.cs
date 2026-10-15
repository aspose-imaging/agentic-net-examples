// HOW-TO: Batch Convert Multiple CDR Files to 24‑Bit BMP in C# (Aspose.Imaging for .NET)
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

namespace CdrToBmpBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = @"C:\InputCdr";
                string outputDirectory = @"C:\OutputBmp";

                Directory.CreateDirectory(outputDirectory);

                string[] inputFiles = Directory.GetFiles(inputDirectory, "*.cdr");

                foreach (string inputPath in inputFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".bmp");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(inputPath))
                    {
                        var bmpOptions = new BmpOptions
                        {
                            BitsPerPixel = 24
                        };
                        image.Save(outputPath, bmpOptions);
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
 * 1. When a graphic design studio needs to export a whole folder of CorelDRAW (.cdr) illustrations to standard 24‑bit BMP files for legacy Windows applications.
 * 2. When an automated build pipeline must generate high‑color BMP assets from CDR source files for inclusion in a game’s texture library.
 * 3. When a document management system requires batch conversion of uploaded CDR drawings to BMP to ensure compatibility with OCR tools that only read BMP format.
 * 4. When a Windows service processes incoming CDR files and saves them as 24‑bit BMP images for printing devices that accept only BMP input.
 * 5. When a developer wants to create a simple .NET utility that scans a directory, loads each CDR with Aspose.Imaging, and saves them as BMP with a fixed color depth for archival purposes.
 */
