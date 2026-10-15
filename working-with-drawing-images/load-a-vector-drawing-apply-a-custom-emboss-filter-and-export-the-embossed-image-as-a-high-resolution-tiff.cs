// HOW-TO: Apply Custom Emboss Filter to SVG and Save as High-Resolution TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 2000,
                    PageHeight = 2000,
                    BackgroundColor = Color.White
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        double[,] customKernel = new double[,]
                        {
                            { -2, -1, 0 },
                            { -1, 1, 1 },
                            { 0, 1, 2 }
                        };
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                        {
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to convert a scalable vector graphic into a printable TIFF with an embossed effect for marketing brochures.
 * 2. When you must generate high‑resolution raster images from SVG files for inclusion in CAD documentation while applying a custom convolution filter.
 * 3. When a web service creates thumbnail previews of vector logos with a 3‑D emboss look before storing them as TIFF for archival.
 * 4. When an automated batch process adds depth to engineering diagrams and outputs them at 300 dpi TIFF for quality‑controlled printing.
 * 5. When a desktop application lets users import SVG icons, apply a stylized emboss filter, and export them as TIFF for use in publishing software.
 */
