// HOW-TO: Convert SVG to PNG and Save to Folder in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace SvgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.svg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate PNG thumbnails from SVG icons for a web UI.
 * 2. When you must batch‑process vector graphics into raster images for email newsletters.
 * 3. When an application requires converting user‑uploaded SVG files to PNG for compatibility with older browsers.
 * 4. When you want to store SVG diagrams as PNG files in a file system hierarchy for reporting.
 * 5. When you need to ensure the output directory exists before saving the converted PNG image.
 */
