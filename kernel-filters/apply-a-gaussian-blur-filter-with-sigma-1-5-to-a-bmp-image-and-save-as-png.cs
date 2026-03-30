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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 (odd) and sigma 1.5
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 1.5));

            // Save the result as PNG
            rasterImage.Save(outputPath);
        }
    }
}