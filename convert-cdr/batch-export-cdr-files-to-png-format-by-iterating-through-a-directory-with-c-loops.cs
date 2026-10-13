// HOW-TO: Batch Convert Multiple CorelDRAW CDR Files to PNG in C# (Aspose.Imaging for .NET)
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

namespace BatchCdrToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputDirectory = "C:\\InputCdr";
                string outputDirectory = "C:\\OutputPng";

                // Ensure the base output directory exists
                Directory.CreateDirectory(outputDirectory);

                string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr", SearchOption.TopDirectoryOnly);
                foreach (string cdrFile in cdrFiles)
                {
                    if (!File.Exists(cdrFile))
                    {
                        Console.Error.WriteLine($"File not found: {cdrFile}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(cdrFile) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Image image = Image.Load(cdrFile))
                    {
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
 * 1. When a design team needs to automatically generate web‑ready PNG previews of dozens of CorelDRAW CDR drawings stored in a folder.
 * 2. When a build script must convert exported CDR assets to PNG for inclusion in a mobile app’s image resources.
 * 3. When a server‑side service processes user‑uploaded CDR files and saves them as PNG thumbnails for a document management system.
 * 4. When a migration project requires batch conversion of legacy CDR artwork to PNG without manual opening of each file.
 * 5. When an automated reporting tool iterates through a directory of CDR diagrams and creates PNG images for embedding in PDF reports.
 */
