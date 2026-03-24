using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.webp";
        string outputPath = @"c:\temp\sample.blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image, apply Gaussian blur, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access the Filter method
            WebPImage webpImage = (WebPImage)image;

            // Apply Gaussian blur to the whole image (radius 5, sigma 4.0)
            webpImage.Filter(webpImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            webpImage.Save(outputPath, new PngOptions());
        }
    }
}