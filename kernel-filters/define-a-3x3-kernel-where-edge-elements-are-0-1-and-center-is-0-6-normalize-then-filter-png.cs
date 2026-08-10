// HOW-TO: Apply Custom 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Define the 3x3 kernel with edge elements 0.1 and center 0.6
                double[,] kernel = new double[3, 3]
                {
                    { 0.1, 0.1, 0.1 },
                    { 0.1, 0.6, 0.1 },
                    { 0.1, 0.1, 0.1 }
                };

                // Normalize the kernel so that the sum of all elements equals 1
                double sum = 0.0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                double[,] normalizedKernel = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        normalizedKernel[i, j] = kernel[i, j] / sum;
                    }
                }

                // Apply the custom convolution filter to the entire image
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(normalizedKernel);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Save the filtered image as PNG
                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                rasterImage.Save(outputPath, saveOptions);
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
 * 1. When you need to smooth a PNG image while preserving overall brightness using a custom weighted kernel.
 * 2. When you want to add a simple blur effect to a PNG in a C# desktop application without third‑party image libraries.
 * 3. When you must preprocess PNG textures for a game to reduce high‑frequency noise before they are loaded into the engine.
 * 4. When you are building an image‑processing pipeline that requires a normalized convolution filter to ensure consistent results across different PNG files.
 * 5. When you need to programmatically apply the same custom filter to multiple PNG files during batch processing.
 */
