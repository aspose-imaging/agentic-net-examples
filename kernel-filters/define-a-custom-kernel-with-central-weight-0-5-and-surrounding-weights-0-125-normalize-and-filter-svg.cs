// HOW-TO: Apply Custom Convolution Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input/input.svg";
            string tempPngPath = "temp/temp.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                // Configure rasterization options
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                // Set PNG save options with rasterization
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized PNG to temporary file
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                // Define custom 3x3 kernel (central 0.5, surrounding 0.125) and normalize
                double sum = 0.5 + 8 * 0.125; // 1.5
                double central = 0.5 / sum;   // 0.333333...
                double surrounding = 0.125 / sum; // 0.083333...

                double[,] kernel = new double[,]
                {
                    { surrounding, surrounding, surrounding },
                    { surrounding, central,     surrounding },
                    { surrounding, surrounding, surrounding }
                };

                // Create convolution filter options (factor = 1.0, bias = 0)
                ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the filtered image to the final output path
                rasterImage.Save(outputPath);
            }

            // Optionally delete the temporary PNG
            if (File.Exists(tempPngPath))
            {
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
 * 1. When you need to sharpen or blur an SVG image by applying a custom filter before converting it to a raster PNG in a .NET application.
 * 2. When you want to ensure consistent visual appearance across different devices by rasterizing SVGs with a specific kernel‑based smoothing effect in C#.
 * 3. When you are building an automated image‑processing pipeline that requires custom weighting of pixel neighborhoods for SVG assets before storing them as PNG files.
 * 4. When you must preprocess vector graphics to reduce noise or emphasize edges using a 3×3 kernel prior to generating thumbnails or previews in a web service.
 * 5. When you are integrating Aspose.Imaging into a C# project to apply a user‑defined convolution filter to SVG content and output the result as a high‑quality PNG.
 */
