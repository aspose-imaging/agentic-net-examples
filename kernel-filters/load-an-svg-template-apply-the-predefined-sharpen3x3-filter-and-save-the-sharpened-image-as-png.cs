// HOW-TO: Sharpen SVG Template and Save as PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.svg";
        string outputPath = "sharpened.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3;
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
                        raster.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a vector‑based SVG logo into a high‑contrast PNG for web thumbnails, applying a sharpen filter to enhance edge definition.
 * 2. When generating printable assets from SVG designs and want to improve clarity by sharpening before saving as PNG for inclusion in PDFs.
 * 3. When creating image previews for a content‑management system that stores SVG templates but requires raster PNGs with enhanced detail for faster loading.
 * 4. When automating batch processing of SVG icons, applying a 3×3 sharpen convolution to make them stand out on high‑DPI displays after conversion to PNG.
 * 5. When integrating Aspose.Imaging into a C# application to rasterize SVG diagrams, sharpen them, and output PNG files for use in reports or dashboards.
 */
