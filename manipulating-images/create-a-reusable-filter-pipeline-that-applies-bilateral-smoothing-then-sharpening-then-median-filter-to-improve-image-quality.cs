using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply the filter pipeline, and save the result
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter (kernel size = 5)
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Apply sharpen filter (kernel size = 5, sigma = 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Apply median filter (kernel size = 5)
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}