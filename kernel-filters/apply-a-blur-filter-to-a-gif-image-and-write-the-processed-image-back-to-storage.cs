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
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output_blurred.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            GifImage gifImage = (GifImage)image;

            // Apply Gaussian blur filter to the entire image
            gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to storage
            gifImage.Save(outputPath);
        }
    }
}