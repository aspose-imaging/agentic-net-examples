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
        string inputPath = "input/sample.gif";
        string outputPath = "output/processed.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            GifImage gifImage = (GifImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to storage
            gifImage.Save(outputPath);
        }
    }
}