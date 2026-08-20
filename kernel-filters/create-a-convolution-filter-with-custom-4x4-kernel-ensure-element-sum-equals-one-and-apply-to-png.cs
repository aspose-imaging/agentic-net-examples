// HOW-TO: Apply Custom 4x4 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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

                // Define a 4x4 averaging kernel (sum equals 1)
                double[,] kernel = new double[,]
                {
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 },
                    { 0.0625, 0.0625, 0.0625, 0.0625 }
                };

                // Create convolution filter options with the custom kernel
                var filterOptions = new ConvolutionFilterOptions(kernel)
                {
                    Factor = 1.0,
                    Bias = 0
                };

                // Apply the filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to smooth a PNG image by averaging neighboring pixels using a custom 4x4 kernel in a C# application.
 * 2. When you want to implement a lightweight blur effect without third‑party libraries by applying a normalized convolution filter to raster images.
 * 3. When you must ensure the filter kernel sums to one to preserve overall image brightness while processing PNG files in .NET.
 * 4. When you are building a batch image‑processing pipeline that loads, filters, and saves PNGs automatically on the server.
 * 5. When you need to validate file existence and create output directories before applying image filters in a robust C# console utility.
 */
