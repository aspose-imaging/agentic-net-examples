using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgToPngConverter
{
    static void Main()
    {
        // Define input SVG and output PNG file paths
        string dir = @"c:\temp\";
        string inputSvgPath = Path.Combine(dir, "test.svg");
        string outputPngPath = Path.Combine(dir, "test.output.png");

        // Load the SVG image from a file stream
        using (FileStream svgStream = File.OpenRead(inputSvgPath))
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Create rasterization options for the SVG
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the original SVG dimensions
                PageSize = svgImage.Size
            };

            // Create PNG save options and assign the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngOptions);
        }

        Console.WriteLine("SVG has been successfully converted to PNG.");
    }
}