using System;
using Aspose.Imaging.FileFormats.Svg;

class LoadSvgExample
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgPath = @"C:\temp\test.svg";

        // Load the SVG image using the SvgImage constructor that accepts a file path
        using (SvgImage svgImage = new SvgImage(svgPath))
        {
            // The image is now loaded and can be used.
            // Example: output basic information about the loaded SVG.
            Console.WriteLine($"SVG loaded successfully.");
            Console.WriteLine($"Width: {svgImage.Width} px");
            Console.WriteLine($"Height: {svgImage.Height} px");
        }
    }
}