// HOW-TO: Check Gaussian Blur Artifacts on SVG Rasterization in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string originalOutputPath = @"C:\temp\original.png";
            string blurredOutputPath = @"C:\temp\blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredOutputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG -> PNG conversion
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                // PNG save options with vector rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image as RasterImage
                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        // Save the original rasterized PNG
                        raster.Save(originalOutputPath);

                        // Apply Gaussian blur filter
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                        // Save the blurred image
                        raster.Save(blurredOutputPath);
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
 * 1. When you need to verify that applying a Gaussian blur to a rasterized SVG does not create visual artifacts in the resulting PNG using Aspose.Imaging for .NET.
 * 2. When you want to automate quality checks for image processing pipelines that convert SVG files to PNG and then apply blur filters.
 * 3. When you are building a service that generates blurred PNG thumbnails from user‑uploaded SVG graphics and must ensure edge fidelity.
 * 4. When you compare the original rasterized SVG PNG with a blurred version to confirm anti‑aliasing and smoothing settings are preserved.
 * 5. When you integrate Aspose.Imaging into a C# workflow to produce high‑resolution PNGs from vector SVGs and apply Gaussian blur without degrading image quality.
 */
