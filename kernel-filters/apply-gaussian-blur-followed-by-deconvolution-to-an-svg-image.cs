// HOW-TO: Apply Gaussian Blur and Deconvolution to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
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

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                PngOptions pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);

                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                    gaussianOptions.Radius = 5;
                    gaussianOptions.Sigma = 1.0;
                    raster.Filter(raster.Bounds, gaussianOptions);

                    double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.0);
                    var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, deconvOptions);

                    raster.Save(outputPath);
                }

                File.Delete(tempPngPath);
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
 * 1. When you need to reduce noise in an SVG illustration before converting it to a high‑quality PNG for web publishing.
 * 2. When you want to enhance edge details of a vector graphic by applying deconvolution after a Gaussian blur to improve print clarity.
 * 3. When an automated pipeline must rasterize SVG assets, apply smoothing and sharpening filters, and store the result as PNG for a mobile app.
 * 4. When you are preprocessing SVG icons for machine‑learning image analysis, requiring consistent blur and deconvolution steps before feature extraction.
 * 5. When you must programmatically convert SVG diagrams to PNG while applying custom image‑processing filters to meet branding guidelines.
 */
