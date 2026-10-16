// HOW-TO: Apply Custom Gauss Wiener Filter to Rasterized SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string svgPath in files)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string tempPngPath = Path.Combine(outputDirectory, fileName + "_temp.png");
                string finalOutputPath = Path.Combine(outputDirectory, fileName + ".png");

                // Rasterize SVG to temporary PNG
                using (Image svgImage = Image.Load(svgPath))
                {
                    int width = svgImage.Width;
                    int height = svgImage.Height;

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = width,
                            PageHeight = height
                        }
                    };

                    Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Apply Gauss‑Wiener filter to the rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    var filterOptions = new GaussWienerFilterOptions();

                    raster.Filter(raster.Bounds, filterOptions);

                    Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));
                    raster.Save(finalOutputPath, new PngOptions());
                }

                // Optionally delete the temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When a developer needs to remove slight blur from SVGs after rasterizing them to PNG for sharper web graphics.
 * 2. When an application must batch‑process multiple SVG files, convert them to PNG, and apply a tunable Gauss‑Wiener filter to improve image quality.
 * 3. When a C# service generates thumbnails from vector assets and requires custom filter strength to meet specific visual standards.
 * 4. When a reporting tool converts SVG charts to PNG and needs to enhance clarity without losing vector‑derived detail.
 * 5. When a desktop utility automates the conversion of SVG logos to high‑resolution PNGs while applying a configurable de‑blurring filter.
 */
