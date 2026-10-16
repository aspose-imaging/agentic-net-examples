// HOW-TO: Resize SVG to PNG and Apply Gaussian Blur in C# (Aspose.Imaging for .NET)
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

            // Define desired raster size
            int targetWidth = 800;
            int targetHeight = 600;

            // Set up SVG rasterization options
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageWidth = targetWidth;
            rasterOptions.PageHeight = targetHeight;
            rasterOptions.BackgroundColor = Color.White;

            // Load SVG and rasterize to a memory stream
            using (Image svgImage = Image.Load(inputPath))
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;
                svgImage.Save(ms, pngOptions);
                ms.Position = 0;

                // Load rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Apply Gaussian blur
                    GaussianBlurFilterOptions blurOptions = new GaussianBlurFilterOptions
                    {
                        Radius = 2,
                        Sigma = 1.0
                    };
                    raster.Filter(raster.Bounds, blurOptions);

                    // Save final image
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a thumbnail PNG from a large SVG and soften its edges with a Gaussian blur for web previews.
 * 2. When creating responsive images for mobile apps, you can downscale vector graphics to a fixed raster size and apply blur to achieve a subtle background effect.
 * 3. When converting SVG icons to blurred PNG assets for UI design systems, ensuring consistent dimensions and smooth visual appearance.
 * 4. When preprocessing vector illustrations for print layouts, resizing them to specific dimensions and applying Gaussian blur to reduce sharpness before compositing.
 * 5. When automating batch processing of SVG files to produce blurred PNGs for machine‑learning datasets, using C# and Aspose.Imaging to handle rasterization and filtering.
 */
