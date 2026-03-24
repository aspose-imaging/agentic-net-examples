using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dib";
        string outputPath = "output\\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DIB image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Apply a sharpen filter (used here for edge detection)
            image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the transformed image as PNG
            PngOptions options = new PngOptions();
            image.Save(outputPath, options);
        }
    }
}