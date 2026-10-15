// HOW-TO: Batch Resize and Blur Images to 800x800 and Convert to SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached)
                    {
                        image.CacheData();
                    }

                    image.Resize(800, 800);
                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5);
                    image.Filter(image.Bounds, blurOptions);

                    var svgOptions = new SvgOptions();
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate web‑ready SVG thumbnails from a folder of photos, resizing them to a uniform 800×800 size and adding a subtle blur for a consistent look.
 * 2. When preparing a batch of product images for an e‑commerce site that requires vector SVG files with a fixed dimension and a soft focus effect.
 * 3. When automating the conversion of scanned documents or raster graphics into scalable SVGs while standardizing their size and applying a Gaussian blur to reduce noise.
 * 4. When creating stylized icons from a collection of bitmap assets, ensuring each icon is 800×800 pixels, blurred, and saved as SVG for responsive UI design.
 * 5. When processing a large set of user‑uploaded images on a server, resizing them, applying a blur filter for privacy, and storing them as lightweight SVG files for faster delivery.
 */
