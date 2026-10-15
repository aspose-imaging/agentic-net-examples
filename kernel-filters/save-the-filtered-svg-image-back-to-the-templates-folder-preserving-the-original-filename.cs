// HOW-TO: Sharpen SVG and Save as PNG in Same Folder C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.svg";
            string outputPath = "templates/input.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height
                        }
                    };
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert an SVG template to a high‑resolution PNG and apply a sharpening filter before using it in a web page.
 * 2. When you want to automate batch processing of vector graphics stored in a templates folder, preserving original filenames while outputting filtered PNGs.
 * 3. When a reporting tool requires raster images with enhanced edges, you can load SVGs, rasterize them, sharpen, and save as PNGs programmatically.
 * 4. When integrating dynamic graphics into a .NET application, you may need to convert user‑provided SVGs to PNGs with custom convolution filters for better visual quality.
 * 5. When preparing assets for email newsletters, you can transform SVG logos into sharpened PNG files without manually editing each image.
 */
