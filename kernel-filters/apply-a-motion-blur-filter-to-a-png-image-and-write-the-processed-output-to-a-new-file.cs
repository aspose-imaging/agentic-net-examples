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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion blur effect using MotionWienerFilterOptions
            // Parameters: length = 10, smooth = 1.0, angle = 0 degrees
            rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Save the processed image to the output path
            rasterImage.Save(outputPath);
        }
    }
}