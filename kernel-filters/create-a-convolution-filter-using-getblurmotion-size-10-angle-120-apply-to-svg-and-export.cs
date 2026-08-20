// HOW-TO: Apply Motion Blur to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.Convolution;
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

            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // PNG options that use the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Create convolution kernel and apply filter
                        var kernel = ConvolutionFilter.GetBlurMotion(10, 120);
                        rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                        // Save the filtered raster image
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
 * 1. When you need to add a realistic motion‑blur effect to vector graphics before converting them to raster PNGs for web thumbnails.
 * 2. When generating product catalog images where SVG logos must be softened with a directional blur to match a design style.
 * 3. When preprocessing SVG assets for a game UI, applying a motion blur filter to create dynamic background elements saved as PNG.
 * 4. When automating batch conversion of SVG illustrations to PNG with a specific blur angle to simulate camera movement in reports.
 * 5. When integrating Aspose.Imaging in a C# service that receives SVG files, applies a custom convolution filter, and returns blurred PNGs for downstream image analysis.
 */
