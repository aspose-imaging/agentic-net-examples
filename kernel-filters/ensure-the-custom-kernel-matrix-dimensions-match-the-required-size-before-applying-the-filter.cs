// HOW-TO: Apply Custom 3x3 Sharpen Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define a custom convolution kernel (example 3x3 sharpen kernel)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Validate kernel dimensions: must be square and odd-sized
            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows != cols || rows % 2 == 0)
            {
                Console.Error.WriteLine("Kernel must be square with odd dimensions.");
                return;
            }

            // Load the image as a raster image and apply the custom filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Create convolution filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the processed image
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
 * 1. When you need to sharpen a PNG image using a custom 3x3 convolution kernel in a C# application.
 * 2. When you want to ensure a user‑provided kernel is square and odd‑sized before applying it with Aspose.Imaging.
 * 3. When you must programmatically process images in bulk, applying the same custom filter to each file.
 * 4. When you need to validate input files and create output directories automatically while performing image filtering.
 * 5. When you are integrating Aspose.Imaging into a .NET service that requires custom image enhancement without external libraries.
 */
