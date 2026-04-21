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
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}