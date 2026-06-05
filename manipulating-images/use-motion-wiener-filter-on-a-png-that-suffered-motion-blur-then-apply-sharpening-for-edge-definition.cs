using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\blurred.png";
        string outputPath = @"c:\temp\restored.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener filter to reduce motion blur
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new MotionWienerFilterOptions(size: 10, sigma: 1.0, angle: 90.0));

                // Apply Sharpen filter for edge definition
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(size: 5, sigma: 4.0));

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