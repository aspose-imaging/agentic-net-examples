using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Temp\sample.gif";
        string outputPath = @"C:\Temp\sample.EdgeDetected.png";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access the Filter method
            GifImage gifImage = (GifImage)image;

            // Apply a sharpen filter (commonly used for edge detection)
            // Kernel size of 5 and sigma of 4.0 are typical values
            gifImage.Filter(
                gifImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            gifImage.Save(outputPath, new PngOptions());
        }
    }
}