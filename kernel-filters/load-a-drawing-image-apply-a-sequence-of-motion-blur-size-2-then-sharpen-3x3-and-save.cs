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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply a motion blur (using MotionWienerFilterOptions) with size 2
                // Length = 2, Brightness = 1.0 (default), Angle = 0 degrees
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(2, 1.0, 0.0));

                // Apply a sharpen filter with kernel size 3 and sigma 1.0
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

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