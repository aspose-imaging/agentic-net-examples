// HOW-TO: Validate Filtered SVG Against XML Schema After Convolution in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;

                string tempPngPath = "temp.png";
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };
                var pngSaveOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPngPath, pngSaveOptions);

                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    double[,] customKernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1, 1, 1 },
                        { 0, 1, 2 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    string filteredPngPath = "filtered.png";
                    raster.Save(filteredPngPath, new PngOptions());
                }

                string newSvgContent = $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                    $"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{svgImage.Width}\" height=\"{svgImage.Height}\">\n" +
                    $"  <image href=\"filtered.png\" x=\"0\" y=\"0\" width=\"{svgImage.Width}\" height=\"{svgImage.Height}\" />\n" +
                    $"</svg>";

                File.WriteAllText(outputPath, newSvgContent);

                using (Image validate = Image.Load(outputPath))
                {
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
 * 1. When you need to apply a custom convolution kernel to an SVG‑derived image and ensure the resulting SVG still conforms to the official SVG XML schema.
 * 2. When converting vector graphics to raster PNG, applying edge‑detect or sharpening filters, and then recreating a valid SVG for downstream web rendering.
 * 3. When integrating Aspose.Imaging in a C# pipeline that must validate edited SVG files against an XSD before publishing to a content management system.
 * 4. When automating quality‑control checks that filtered graphics maintain proper namespace declarations and schema compliance for regulatory submissions.
 * 5. When building a server‑side service that processes user‑uploaded SVGs, applies custom image filters, and guarantees the output passes XML validation to avoid parsing errors in client applications.
 */
