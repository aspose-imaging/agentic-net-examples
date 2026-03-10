using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageLoadOptions;

class LoadSvgExample
{
    static void Main()
    {
        // Path to the SVG file
        string svgFilePath = @"C:\temp\sample.svg";

        // Create SVG-specific load options
        SvgLoadOptions loadOptions = new SvgLoadOptions();

        // Load the SVG image using the provided Image.Load method
        using (Image image = Image.Load(svgFilePath, loadOptions))
        {
            // Cast the generic Image to SvgImage for SVG-specific operations
            SvgImage svgImage = (SvgImage)image;

            // Example usage: output the dimensions of the loaded SVG
            Console.WriteLine($"Loaded SVG dimensions: {svgImage.Width}x{svgImage.Height}");
        }
    }
}