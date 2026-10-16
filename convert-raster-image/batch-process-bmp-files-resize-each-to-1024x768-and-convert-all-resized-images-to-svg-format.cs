// HOW-TO: Batch Resize BMP Images to 1024x768 and Convert to SVG in C# (Aspose.Imaging for .NET)
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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");
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

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    raster.Resize(1024, 768);

                    using (SvgOptions options = new SvgOptions())
                    {
                        options.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = raster.Width,
                            PageHeight = raster.Height,
                            BackgroundColor = Color.White
                        };

                        raster.Save(outputPath, options);
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
 * 1. When you need to automatically shrink a collection of BMP photos to a standard 1024x768 size before publishing them as scalable SVG graphics.
 * 2. When a legacy system stores screenshots as BMP files and you must batch‑convert them to lightweight SVGs for web display.
 * 3. When preparing assets for a responsive UI, you may resize high‑resolution BMPs and transform them into vector‑compatible SVGs in a single C# routine.
 * 4. When migrating a design library, you can use this code to resize all BMP icons and output them as SVG files for modern browsers.
 * 5. When generating printable diagrams from BMP sources, resizing them to a consistent resolution and converting to SVG ensures crisp scaling without quality loss.
 */
