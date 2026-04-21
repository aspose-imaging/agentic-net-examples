using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

namespace AsposeImagingFilterDemo
{
    internal class Program
    {
        private static void Main()
        {
            // Hardcoded input and output file paths.
            const string inputPath = @"C:\temp\sample.png";
            const string outputPath = @"C:\temp\sample.SharpenFilter.png";

            try
            {
                // Verify that the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists.
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image from the specified file.
                using (Image image = Image.Load(inputPath))
                {
                    // Cast the loaded image to RasterImage to access filtering capabilities.
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply a sharpen filter with a kernel size of 5 and a sigma value of 4.0.
                    // The filter is applied to the entire image bounds.
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the output path.
                    rasterImage.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                // Output any unexpected errors without crashing the application.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}