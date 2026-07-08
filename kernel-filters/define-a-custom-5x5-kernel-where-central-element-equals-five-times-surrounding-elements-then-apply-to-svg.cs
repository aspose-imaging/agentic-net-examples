using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
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
            string tempPath = "temp.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply custom 5x5 convolution kernel, and save final output
            using (Image rasterImageContainer = Image.Load(tempPath))
            {
                var rasterImage = (RasterImage)rasterImageContainer;

                // Define 5x5 kernel: surrounding elements = 1, center = 5
                double[,] kernel = new double[5, 5];
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        kernel[y, x] = 1.0;
                    }
                }
                kernel[2, 2] = 5.0; // central element

                var convOptions = new ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, convOptions);

                // Save the filtered image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to enhance the contrast of vector graphics by applying a custom sharpening filter after rasterizing an SVG to PNG using Aspose.Imaging for .NET.
 * 2. When a developer wants to emphasize central features in a logo or icon by using a 5x5 convolution kernel where the center weight is five times the surrounding weights, converting the SVG to a high‑resolution PNG.
 * 3. When a developer must prepare SVG illustrations for print by applying a custom blur‑sharpen hybrid filter via a 5x5 kernel to improve visual clarity before saving as PNG.
 * 4. When a developer is building an automated pipeline that normalizes SVG assets, rasterizes them, and applies a weighted convolution to reduce noise while preserving detail in the resulting PNG files.
 * 5. When a developer needs to create a thumbnail generator that rasterizes SVG icons and applies a custom kernel to accentuate edges, ensuring the PNG thumbnails retain crisp outlines.
 */