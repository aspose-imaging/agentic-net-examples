using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output\\processed.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load GIF image, apply edge detection (sharpen) filter, and save
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var gifImage = (Aspose.Imaging.FileFormats.Gif.GifImage)image;

            // Apply sharpen filter as a simple edge detection approximation
            gifImage.Filter(gifImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as GIF
            gifImage.Save(outputPath, new GifOptions());
        }
    }
}