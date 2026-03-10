using System;
using Aspose.Imaging;

class LoadSvgExample
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgPath = @"C:\Images\sample.svg";

        // Load the SVG image using the Aspose.Imaging.Image.Load method
        using (Image image = Image.Load(svgPath))
        {
            // The image is now loaded and can be used as a regular Image object
            // Example: retrieve the file format of the loaded image
            var format = image.FileFormat;

            // Output some basic information
            Console.WriteLine($"Loaded image format: {format}");
            Console.WriteLine($"Image dimensions: {image.Width}x{image.Height}");
        }
    }
}