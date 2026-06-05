using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample.BilateralSmoothingFilter.png";

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

            // Load the image, apply the bilateral smoothing filter, and save the result
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access the Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter with kernel size 5
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}