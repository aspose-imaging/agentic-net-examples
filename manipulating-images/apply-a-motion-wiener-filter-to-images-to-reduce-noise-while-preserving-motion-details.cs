using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Motion Wiener filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply motion Wiener filter to the entire image
            // Parameters: size = 10, sigma = 1.0, angle = 90.0 degrees
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}