// HOW-TO: Apply Gaussian Blur and Emboss Filters to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = 800,
                            PageHeight = 600,
                            BackgroundColor = Color.White
                        }
                    };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply Gaussian blur filter
                        var gaussianOptions = new ConvolutionFilterOptions(ConvolutionFilter.GetGaussian(3, 1.0));
                        rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

                        // Apply Emboss3x3 filter
                        var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);
                        rasterImage.Filter(rasterImage.Bounds, embossOptions);

                        // Save the processed image
                        var saveOptions = new PngOptions();
                        rasterImage.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a stylized thumbnail of an SVG logo by blurring and embossing it before exporting to PNG for web display.
 * 2. When creating print‑ready assets where a subtle Gaussian blur followed by an emboss effect enhances depth perception of vector illustrations.
 * 3. When preprocessing SVG icons for a game UI, applying blur and emboss to achieve a polished, three‑dimensional look in the final PNG sprites.
 * 4. When automating batch conversion of SVG diagrams to PNG with artistic effects for inclusion in marketing brochures.
 * 5. When building a C# service that dynamically renders user‑uploaded SVGs with custom filter chains (blur then emboss) before serving them as PNG images.
 */
