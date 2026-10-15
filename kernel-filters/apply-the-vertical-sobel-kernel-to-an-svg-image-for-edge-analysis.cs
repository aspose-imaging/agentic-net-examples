// HOW-TO: Apply Vertical Sobel Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var svg = (Aspose.Imaging.FileFormats.Svg.SvgImage)svgImage;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svg.Width,
                    PageHeight = svg.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svg.Save(tempPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                double[,] sobelVertical = new double[,]
                {
                    { -1, 0, 1 },
                    { -2, 0, 2 },
                    { -1, 0, 1 }
                };

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelVertical));

                using (var outOptions = new PngOptions())
                {
                    raster.Save(outputPath, outOptions);
                }
            }

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When you need to extract vertical edges from a vector diagram and output a raster PNG for further computer‑vision processing.
 * 2. When you want to convert an SVG logo to a high‑resolution PNG while highlighting structural outlines for quality‑control checks.
 * 3. When building a web service that analyses technical drawings and requires edge maps generated from SVG files using a Sobel filter in C#.
 * 4. When preparing training data for a machine‑learning model that classifies shapes, and you must preprocess SVG assets with vertical edge detection before saving them as PNGs.
 * 5. When automating batch processing of SVG icons to create stylized edge‑enhanced PNG thumbnails for UI design tools.
 */
