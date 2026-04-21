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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply motion blur (size 2) using MotionWienerFilterOptions
                // Parameters: length = 2, smooth = 1.0 (default), angle = 0 degrees
                var motionOptions = new MotionWienerFilterOptions(2, 1.0, 0.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Apply sharpen filter with a 3x3 kernel (size = 3, sigma = 1.0)
                var sharpenOptions = new SharpenFilterOptions(3, 1.0);
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

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