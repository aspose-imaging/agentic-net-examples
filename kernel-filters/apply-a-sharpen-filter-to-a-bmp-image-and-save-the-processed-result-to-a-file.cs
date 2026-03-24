using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output_sharpened.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image, apply Sharpen filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            var rasterImage = (RasterImage)image;

            // Apply Sharpen filter with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to the output path
            rasterImage.Save(outputPath);
        }
    }
}