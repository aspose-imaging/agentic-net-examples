using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 and sigma 1.5 to the whole image
            var blurOptions = new GaussianBlurFilterOptions(5, 1.5);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the result as PNG (format inferred from file extension)
            rasterImage.Save(outputPath);
        }
    }
}