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

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Set up PNG save options with the rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Define custom 3x3 kernel
                        double[,] kernel = new double[3, 3];
                        for (int y = 0; y < 3; y++)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                kernel[y, x] = 0.125;
                            }
                        }
                        kernel[1, 1] = 0.5; // central weight

                        // Normalize kernel (sum = 1.5)
                        double sum = 0.0;
                        foreach (double v in kernel) sum += v;
                        for (int y = 0; y < 3; y++)
                        {
                            for (int x = 0; x < 3; x++)
                            {
                                kernel[y, x] /= sum;
                            }
                        }

                        // Apply convolution filter
                        ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel, 0, 3);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered image
                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to convert an SVG logo to a high‑resolution PNG while applying a custom blur filter to smooth edges for web publishing.
 * 2. When a mobile app must render vector icons as raster images with a subtle sharpening effect using a 3×3 kernel to improve readability on low‑dpi screens.
 * 3. When an e‑commerce platform generates product thumbnails from SVG diagrams and wants to reduce visual noise by applying a normalized kernel with a central weight of 0.5.
 * 4. When a reporting tool exports SVG charts to PNG and requires a consistent softening filter to match the style of other raster graphics in the PDF report.
 * 5. When a game UI pipeline rasterizes SVG assets to PNG and uses a custom kernel to achieve a vignette‑like fade around the edges for a polished visual effect.
 */