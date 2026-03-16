using System;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgPath = @"C:\Images\sample.svg";

        // Instantiate an SvgImage object from the file path.
        // This loads the vector content and makes it available for further processing.
        using (SvgImage svgImage = new SvgImage(svgPath))
        {
            // Example: output basic information about the loaded SVG.
            Console.WriteLine($"Width: {svgImage.Width}");
            Console.WriteLine($"Height: {svgImage.Height}");
            Console.WriteLine($"File format: {svgImage.FileFormat}");

            // Additional vector processing can be performed here.
            // For instance, you could rasterize, edit, or analyze the SVG content.
        }
    }
}