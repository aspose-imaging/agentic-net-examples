// HOW-TO: Batch Convert Multiple SVG Files to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "InputSvgs";
            string outputDir = "OutputPngs";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White
            };

            using (var pngOptions = new PngOptions())
            {
                pngOptions.VectorRasterizationOptions = rasterOptions;

                string[] files = Directory.GetFiles(inputDir, "*.svg");
                foreach (var file in files)
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(file) + ".png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(file))
                    {
                        image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate web‑ready PNG thumbnails from a folder of SVG icons using a single set of rasterization settings.
 * 2. When an automated build process must convert a collection of vector logos to PNG for inclusion in PDF reports.
 * 3. When a desktop application has to export user‑created SVG diagrams as high‑quality PNG images in bulk.
 * 4. When a CI pipeline must rasterize SVG assets with a white background for consistent rendering on dark themes.
 * 5. When migrating legacy SVG assets to PNG for compatibility with systems that only support raster image formats.
 */
