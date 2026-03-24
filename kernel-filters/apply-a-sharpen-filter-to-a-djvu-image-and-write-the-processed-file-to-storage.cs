using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\sample_sharpened.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DJVU image, apply sharpen filter, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply sharpen filter to the entire image (kernel size 5, sigma 4.0)
            djvuImage.Filter(djvuImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}