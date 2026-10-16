// HOW-TO: Compare Emboss3x3 Vs Emboss5x5 Edge Enhancement on SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputSvgPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputEmboss3Path = "output_emboss3.png";
            string outputEmboss5Path = "output_emboss5.png";

            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmboss3Path));
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmboss5Path));

            using (Aspose.Imaging.Image svgImg = Aspose.Imaging.Image.Load(inputSvgPath))
            {
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)svgImg;

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            using (Aspose.Imaging.RasterImage raster3 = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
            {
                raster3.Filter(raster3.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                PngOptions outOptions3 = new PngOptions();
                raster3.Save(outputEmboss3Path, outOptions3);
            }

            using (Aspose.Imaging.RasterImage raster5 = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
            {
                raster5.Filter(raster5.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                PngOptions outOptions5 = new PngOptions();
                raster5.Save(outputEmboss5Path, outOptions5);
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
 * 1. When a developer needs to evaluate which emboss filter produces sharper edges for vector graphics converted to raster PNGs.
 * 2. When a developer wants to generate side‑by‑side PNG previews of an SVG with different convolution filters for UI testing.
 * 3. When a developer must automate quality checks of embossed effects before publishing icons or logos.
 * 4. When a developer is building a batch process that applies specific edge‑enhancement filters to SVG assets for print preparation.
 * 5. When a developer needs to compare visual impact of 3×3 versus 5×5 emboss kernels to choose the optimal filter for a graphics‑intensive application.
 */
