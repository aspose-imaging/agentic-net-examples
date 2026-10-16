// HOW-TO: Convert ODG File to PNG from Memory Stream in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                byte[] fileBytes = File.ReadAllBytes(inputPath);
                using (var memoryStream = new MemoryStream(fileBytes))
                {
                    using (var image = Image.Load(memoryStream))
                    {
                        string outputDir = Path.GetDirectoryName(outputPath);
                        Directory.CreateDirectory(outputDir ?? ".");

                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
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
 * 1. When a desktop application needs to display OpenDocument graphics by converting ODG files to PNG images stored in memory.
 * 2. When a web API receives an uploaded ODG file as a byte array and must return a PNG thumbnail without writing intermediate files to disk.
 * 3. When an automated batch process reads ODG documents from a database BLOB, converts them to PNG for reporting, and saves the results to a network folder.
 * 4. When a mobile backend service processes user‑generated ODG drawings and stores them as PNGs for fast loading on client devices.
 * 5. When a document‑management system migrates legacy ODG assets to PNG format using Aspose.Imaging to ensure compatibility with standard image viewers.
 */
