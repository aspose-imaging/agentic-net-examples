using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\blurred.png";
            string outputPath = @"C:\Images\restored.png";

            // Verify input file exists
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
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener filter to reduce motion blur
                var motionOptions = new MotionWienerFilterOptions(10, 1.0, 90.0);
                rasterImage.Filter(rasterImage.Bounds, motionOptions);

                // Apply Sharpen filter for edge definition
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                // Save the processed image as PNG
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}