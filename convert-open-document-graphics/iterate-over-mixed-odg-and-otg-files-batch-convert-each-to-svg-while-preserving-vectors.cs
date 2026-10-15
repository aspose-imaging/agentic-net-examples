// HOW-TO: Batch Convert ODG and OTG Files to SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchConvertOpenDocumentGraphics
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\Input";
                string outputDirectory = @"C:\Output";

                // Get all .odg and .otg files in the input directory
                var files = Directory.GetFiles(inputDirectory)
                    .Where(f => f.EndsWith(".odg", StringComparison.OrdinalIgnoreCase) ||
                                f.EndsWith(".otg", StringComparison.OrdinalIgnoreCase));

                foreach (var inputPath in files)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Determine output path with .svg extension
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".svg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the ODG/OTG image and save as SVG
                    using (Image image = Image.Load(inputPath))
                    {
                        var options = new SvgOptions();
                        image.Save(outputPath, options);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to migrate a library of OpenDocument graphics (ODG/OTG) to scalable SVG files for web display without losing vector quality.
 * 2. When an automated build process must convert newly added ODG or OTG assets into SVG format for inclusion in a responsive UI.
 * 3. When a document management system requires batch exporting of mixed ODG/OTG diagrams to SVG so they can be indexed by search engines.
 * 4. When a designer wants to generate SVG previews of multiple OpenDocument drawings in a single C# script using Aspose.Imaging.
 * 5. When a server‑side application must ensure an output folder contains SVG versions of all ODG/OTG files for downstream processing.
 */
