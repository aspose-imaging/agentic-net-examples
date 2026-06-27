using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage for vector-specific properties
                SvgImage svgImage = (SvgImage)image;

                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Prepare PNG options with the rasterization settings
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

                        // Create convolution kernel for motion blur (size 10, angle 120)
                        double[,] kernel = ConvolutionFilter.GetBlurMotion(10, 120);
                        ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);

                        // Apply the convolution filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered raster image as PNG
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
 * 1. When a web developer needs to add a realistic motion‑blur effect to an SVG logo before converting it to a PNG for high‑resolution marketing assets, they can use this C# Aspose.Imaging code.
 * 2. When a desktop application must programmatically generate blurred map overlays from vector SVG files and export them as PNG tiles for GIS viewers, the convolution filter with GetBlurMotion size 10 angle 120 is ideal.
 * 3. When an e‑learning platform wants to create animated‑style illustrations by applying a directional blur to SVG diagrams and saving them as PNG images for faster loading on mobile devices, this code provides a simple solution.
 * 4. When a game developer needs to preprocess vector UI elements with a 120‑degree motion blur and rasterize them to PNG sprites for use in a 2D engine, the Aspose.Imaging filter pipeline handles it automatically.
 * 5. When a reporting tool generates SVG charts that must be visually softened with a specific motion blur before embedding them as PNG images in PDF reports, this C# snippet accomplishes the task efficiently.
 */