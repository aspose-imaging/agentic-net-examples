// HOW-TO: Apply Custom 5x5 Kernel Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Rasterize SVG to a temporary PNG
                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                image.Save(tempPngPath, pngOptions);

                // Load the rasterized PNG as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(tempPngPath))
                {
                    // Define custom 5x5 kernel (center = 5 * surrounding)
                    double[,] kernel = new double[5, 5];
                    for (int y = 0; y < 5; y++)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            kernel[y, x] = 1.0;
                        }
                    }
                    kernel[2, 2] = 5.0; // central element

                    // Apply convolution filter
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                    // Save the filtered image
                    rasterImage.Save(outputPath);
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to enhance an SVG graphic with a custom sharpening effect before converting it to a PNG in a .NET application.
 * 2. When you want to programmatically apply a 5x5 convolution kernel where the center pixel is weighted five times more than its neighbors to any vector image.
 * 3. When you must rasterize an SVG to a bitmap, apply a bespoke filter, and save the result without using external image editors.
 * 4. When your C# code has to ensure the output folder exists and handle missing input files while processing SVG images with Aspose.Imaging.
 * 5. When you are building an automated pipeline that processes SVG assets, applies custom image filters, and generates PNG thumbnails for web use.
 */
