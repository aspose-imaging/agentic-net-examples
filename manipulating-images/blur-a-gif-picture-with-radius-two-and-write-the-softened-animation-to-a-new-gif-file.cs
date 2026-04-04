using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific functionality
            GifImage gif = (GifImage)image;

            // Apply a Gaussian blur with radius 2 (sigma set to 1.0)
            gif.Filter(gif.Bounds, new GaussianBlurFilterOptions(2, 1.0));

            // Save the blurred animation to the output file
            gif.Save(outputPath);
        }
    }
}