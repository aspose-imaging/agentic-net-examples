using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgToPngConverter
{
    static void Main()
    {
        // Define input SVG file and output PNG file paths
        string inputSvgPath = @"C:\Temp\example.svg";
        string outputPngPath = @"C:\Temp\example.png";

        // Open a read-only file stream for the SVG file
        using (Stream svgStream = File.OpenRead(inputSvgPath))
        // Load the SVG image from the stream
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Create rasterization options required for converting vector SVG to raster PNG
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

            // Create PNG save options and assign the rasterization options
            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngSaveOptions);
        }

        Console.WriteLine("SVG has been successfully converted to PNG.");
    }
}