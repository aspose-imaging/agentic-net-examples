using System;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgFilePath = @"C:\Images\example.svg";

        // Load the SVG image using the SvgImage constructor that accepts a file path
        using (SvgImage svgImage = new SvgImage(svgFilePath))
        {
            // Optional: cache the image data to avoid further lazy loading
            svgImage.CacheData();

            // At this point the SVG image is loaded and ready for processing
            // Example: output image dimensions
            Console.WriteLine($"Width: {svgImage.Width}, Height: {svgImage.Height}");
        }
    }
}