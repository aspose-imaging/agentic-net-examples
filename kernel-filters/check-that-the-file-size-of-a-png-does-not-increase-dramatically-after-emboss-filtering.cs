using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output_emboss.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Record original file size
                long originalSize = new FileInfo(inputPath).Length;

                // Apply emboss filter using convolution kernel
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Save the filtered image with default PNG options
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);

                // Record new file size
                long newSize = new FileInfo(outputPath).Length;

                // Output size information
                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Embossed size: {newSize} bytes");
                double ratio = (double)newSize / originalSize;
                Console.WriteLine($"Size increase ratio: {ratio:F2}");

                if (ratio > 1.5)
                {
                    Console.WriteLine("Warning: File size increased dramatically after emboss filtering.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}