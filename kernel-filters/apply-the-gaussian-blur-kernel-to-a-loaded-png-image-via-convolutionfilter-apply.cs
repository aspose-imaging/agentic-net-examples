using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.GaussianBlur.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage rasterImage = (RasterImage)image;

            // Create Gaussian blur filter options (size = 5, sigma = 4.0)
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

            // Apply the Gaussian blur to the entire image bounds
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}