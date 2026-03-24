using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.wmz";
        string outputPath = @"C:\Images\sample_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMZ image, apply Sharpen filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Filter method
            var rasterImage = (RasterImage)image;

            // Apply Sharpen filter with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}