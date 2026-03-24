using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output\\processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image, apply Sharpen filter, and save as PNG
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Apply sharpen filter with kernel size 5 and sigma 4.0
            webPImage.Filter(
                webPImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image
            webPImage.Save(outputPath, new PngOptions());
        }
    }
}