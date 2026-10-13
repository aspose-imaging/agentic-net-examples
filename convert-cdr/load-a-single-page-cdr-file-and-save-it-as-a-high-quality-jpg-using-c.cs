// HOW-TO: Convert Single Page CDR to High Quality JPG in C# (Aspose.Imaging for .NET)
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

namespace CdrToJpgConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100
                    };
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a designer needs to export a CorelDRAW (CDR) illustration as a high‑resolution JPEG for inclusion in a web page or marketing material.
 * 2. When an automated build pipeline must convert generated CDR assets to JPEGs to ensure compatibility with downstream image processing tools.
 * 3. When a legacy application only supports JPEG input, requiring conversion of single‑page CDR files before they can be displayed in the UI.
 * 4. When a content management system stores original CDR files but needs to create high‑quality JPG previews for end‑users without losing detail.
 * 5. When a batch script processes individual CDR drawings and saves them as 100‑percent quality JPEGs for archival or printing purposes.
 */
