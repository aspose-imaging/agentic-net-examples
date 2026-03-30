using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "templates\\sample.png";
        string outputPath = "output\\sample_blurred.png";

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
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a 5x5 box blur using a Gaussian blur approximation
            // Radius 5 approximates a 5x5 kernel; sigma value chosen for moderate blur
            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, blurOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}