using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgFilePath = @"C:\temp\example.svg";

        // Load the SVG image from the file using the Aspose.Imaging.Image.Load method
        // This follows the provided load rule and returns an Image instance
        using (Image image = Image.Load(svgFilePath))
        {
            // Cast the generic Image to SvgImage to access SVG‑specific members
            SvgImage svgImage = (SvgImage)image;

            // Optional: cache the image data to avoid further lazy loading
            svgImage.CacheData();

            // The SVG image is now fully loaded in memory and can be manipulated or rendered
            // Additional processing can be performed here
        }
    }
}