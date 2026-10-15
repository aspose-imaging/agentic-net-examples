// HOW-TO: Batch Apply Gaussian Blur to PNGs and Convert to SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                    raster.Filter(raster.Bounds, blurOptions);

                    var svgOptions = new SvgOptions();
                    raster.Save(outputPath, svgOptions);
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
 * 1. When you need to automatically soften a collection of PNG icons before embedding them in a vector‑based UI, you can batch blur and convert them to SVG.
 * 2. When preparing assets for responsive web design, you may want to apply a consistent blur effect to all raster images and output scalable SVG files for faster loading.
 * 3. When creating stylized diagrams from scanned PNG sketches, applying a Gaussian blur and converting to SVG helps smooth edges and produce clean vector graphics.
 * 4. When migrating a legacy PNG asset library to a modern vector format while preserving a specific blur effect, this code automates the conversion for every file in a folder.
 * 5. When generating blurred placeholders for lazy‑loaded images, converting the blurred PNGs to SVG ensures they remain lightweight and resolution‑independent.
 */
