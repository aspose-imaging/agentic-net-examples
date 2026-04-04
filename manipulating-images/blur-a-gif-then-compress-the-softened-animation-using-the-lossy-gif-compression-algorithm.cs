using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            GifImage gif = (GifImage)image;

            // Apply Gaussian blur to the entire GIF
            gif.Filter(gif.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Configure lossy compression
            GifOptions options = new GifOptions
            {
                MaxDiff = 80 // Recommended value for lossy compression
            };

            // Save the blurred GIF with lossy compression
            gif.Save(outputPath, options);
        }
    }
}