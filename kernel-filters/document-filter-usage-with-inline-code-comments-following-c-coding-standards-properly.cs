using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

namespace AsposeImagingDemo
{
    class Program
    {
        static void Main()
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.SharpenFilter.png";

            try
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering capabilities
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the output path
                    rasterImage.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any unexpected errors
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}