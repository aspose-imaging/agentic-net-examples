using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputPath = @"C:\Images\sample_blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to use the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 11 and sigma 4.5 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(11, 4.5));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}