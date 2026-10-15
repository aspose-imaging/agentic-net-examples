// HOW-TO: Batch Convert SVG to PNG with Motion Blur in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                using (Image svgImage = Image.Load(file))
                {
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                    using (var ms = new MemoryStream())
                    {
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            double[,] kernel = ConvolutionFilter.GetBlurMotion(8, 60);
                            var filterOptions = new ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a series of blurred PNG thumbnails from a collection of SVG icons for a web gallery.
 * 2. When an e‑commerce platform wants to apply a consistent motion‑blur effect to product vector graphics before storing them as PNGs for faster loading.
 * 3. When a game developer batch‑processes SVG assets to PNG sprites and adds a motion blur to simulate speed in the final artwork.
 * 4. When a marketing team automates the creation of PNG banners from SVG templates, applying a specific blur size and angle to match a campaign’s visual style.
 * 5. When a reporting tool converts SVG charts to PNG images and adds a motion‑blur filter to emphasize trend direction in printed PDFs.
 */
