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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.webp";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            // Apply a motion Wiener deconvolution filter to the whole image
            // Parameters: radius = 10, sigma = 1.0, angle = 45 degrees
            var deconvOptions = new MotionWienerFilterOptions(10, 1.0, 45.0);
            webpImage.Filter(webpImage.Bounds, deconvOptions);

            // Save the processed image as PNG
            webpImage.Save(outputPath, new PngOptions());
        }
    }
}