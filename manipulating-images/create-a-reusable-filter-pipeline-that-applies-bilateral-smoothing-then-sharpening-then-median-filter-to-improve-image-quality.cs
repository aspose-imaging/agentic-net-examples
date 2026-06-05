using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Apply the filter pipeline and save the result
            ApplyFilterPipeline(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Reusable pipeline: bilateral smoothing -> sharpen -> median filter
    static void ApplyFilterPipeline(string inputPath, string outputPath)
    {
        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply bilateral smoothing filter (kernel size = 5)
            var bilateralOptions = new BilateralSmoothingFilterOptions(5);
            rasterImage.Filter(rasterImage.Bounds, bilateralOptions);

            // Apply sharpen filter (kernel size = 5, sigma = 4.0)
            var sharpenOptions = new SharpenFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

            // Apply median filter (kernel size = 5)
            var medianOptions = new MedianFilterOptions(5);
            rasterImage.Filter(rasterImage.Bounds, medianOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}