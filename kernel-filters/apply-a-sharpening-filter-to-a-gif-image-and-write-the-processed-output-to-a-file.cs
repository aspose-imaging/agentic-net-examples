using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.gif";
        string outputPath = @"C:\Images\sample_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image, apply sharpen filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access the Filter method
            GifImage gifImage = (GifImage)image;

            // Apply sharpen filter to the entire image
            gifImage.Filter(gifImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            gifImage.Save(outputPath, new PngOptions());
        }
    }
}