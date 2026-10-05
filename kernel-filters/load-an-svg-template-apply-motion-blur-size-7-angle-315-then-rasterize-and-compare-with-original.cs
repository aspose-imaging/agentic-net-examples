// HOW-TO: Apply Motion Blur to SVG Rasterization and Compare PNGs in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
            string inputPath = "template.svg";
            string originalRasterPath = "original.png";
            string blurredRasterPath = "blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(originalRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredRasterPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Failed to load SVG image.");
                    return;
                }

                int width = svgImage.Width;
                int height = svgImage.Height;

                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = width,
                    PageHeight = height
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(originalRasterPath, pngOptions);
            }

            // Load original raster image
            using (RasterImage originalRaster = (RasterImage)Image.Load(originalRasterPath))
            {
                // Load a second instance for blurred version
                using (RasterImage blurredRaster = (RasterImage)Image.Load(originalRasterPath))
                {
                    var kernel = ConvolutionFilter.GetBlurMotion(7, 315);
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    blurredRaster.Filter(blurredRaster.Bounds, filterOptions);
                    blurredRaster.Save(blurredRasterPath);
                }
            }

            using (RasterImage orig = (RasterImage)Image.Load(originalRasterPath))
            using (RasterImage blur = (RasterImage)Image.Load(blurredRasterPath))
            {
                bool identical = true;
                if (orig.Width != blur.Width || orig.Height != blur.Height)
                {
                    identical = false;
                }
                else
                {
                    int totalPixels = orig.Width * orig.Height;
                    int[] origPixels = new int[totalPixels];
                    int[] blurPixels = new int[totalPixels];
                    var rect = new Rectangle(0, 0, orig.Width, orig.Height);
                    orig.SaveArgb32Pixels(rect, origPixels);
                    blur.SaveArgb32Pixels(rect, blurPixels);
                    for (int i = 0; i < totalPixels; i++)
                    {
                        if (origPixels[i] != blurPixels[i])
                        {
                            identical = false;
                            break;
                        }
                    }
                }
                Console.WriteLine(identical ? "Images are identical." : "Images differ.");
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
 * 1. When you need to generate a PNG preview of an SVG logo and then create a motion‑blurred version for a dynamic web banner.
 * 2. When you want to programmatically compare a clean rasterized SVG with a blurred variant to detect visual differences in automated testing.
 * 3. When you are building a C# tool that applies a directional blur effect to vector graphics before exporting them as PNG assets for games or UI.
 * 4. When you must batch‑process SVG templates, rasterize them at their native size, and produce a motion‑blur effect for motion‑graphics pipelines.
 * 5. When you require a reproducible way to render an SVG, apply a 7‑pixel blur at a 315° angle, and save both the original and altered PNGs for quality‑control documentation.
 */
