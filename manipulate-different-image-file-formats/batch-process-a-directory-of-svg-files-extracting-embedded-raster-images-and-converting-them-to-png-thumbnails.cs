// HOW-TO: Extract Embedded Images from SVG and Create PNG Thumbnails in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (Image vector = Image.Load(filePath))
                {
                    var vectorImage = (VectorImage)vector;
                    var embeddedImages = vectorImage.GetEmbeddedImages();
                    int index = 0;
                    foreach (EmbeddedImage embedded in embeddedImages)
                    {
                        using (embedded)
                        {
                            string baseName = Path.GetFileNameWithoutExtension(filePath);
                            string outputPath = Path.Combine(outputDirectory, $"{baseName}_thumb_{index}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            using (RasterImage raster = (RasterImage)embedded.Image)
                            {
                                int maxSize = 150;
                                int width = raster.Width;
                                int height = raster.Height;
                                double ratio = Math.Min((double)maxSize / width, (double)maxSize / height);
                                int thumbWidth = (int)(width * ratio);
                                int thumbHeight = (int)(height * ratio);
                                if (thumbWidth <= 0) thumbWidth = 1;
                                if (thumbHeight <= 0) thumbHeight = 1;

                                raster.Resize(thumbWidth, thumbHeight);

                                using (var pngOptions = new PngOptions())
                                {
                                    raster.Save(outputPath, pngOptions);
                                }
                            }

                            index++;
                        }
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
 * 1. When you need to generate preview thumbnails for all raster images embedded in a collection of SVG icons for a web catalog, this code batch‑processes the SVG files and saves PNG previews.
 * 2. When a design pipeline requires extracting bitmap assets from SVG illustrations to reuse them in a mobile app, the script pulls each embedded image and converts it to a PNG of a fixed size.
 * 3. When automating documentation generation, you can use this routine to pull embedded screenshots from SVG diagrams and create small PNG thumbnails for inclusion in PDF reports.
 * 4. When migrating legacy SVG assets that contain embedded JPEGs into a new asset management system, the code extracts those JPEGs, rasterizes them, and stores them as PNG thumbnails for consistent format handling.
 * 5. When building a content‑delivery service that serves low‑resolution previews of SVG‑based charts, this example quickly extracts the chart’s raster layers and outputs 150‑pixel PNG thumbnails for faster loading.
 */
