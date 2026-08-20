// HOW-TO: Apply Custom 3x3 Normalized Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Define a 3x3 kernel with coefficients summing to 1 (simple blur)
                double[,] kernel = new double[,]
                {
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                };

                // Create convolution filter options (factor = 1.0, bias = 0)
                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply the custom convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to blur a PNG image uniformly using a simple 3x3 averaging kernel in a C# application.
 * 2. When you want to implement a custom image filter with coefficients that sum to one to preserve overall brightness.
 * 3. When you must process large batches of PNG files on a server and need a fast, code‑only solution without external libraries.
 * 4. When you are building a photo‑editing tool that lets users apply custom convolution effects such as sharpening or edge detection.
 * 5. When you need to ensure the output directory exists and save the filtered image back to PNG format programmatically.
 */
