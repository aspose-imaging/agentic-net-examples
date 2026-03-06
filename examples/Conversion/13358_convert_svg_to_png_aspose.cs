using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source SVG file
        string inputFile = @"C:\temp\test.svg";
        // Desired path for the resulting PNG file
        string outputFile = @"C:\temp\test.png";

        // Load the SVG image from a file stream
        using (Stream stream = File.OpenRead(inputFile))
        using (SvgImage svgImage = new SvgImage(stream))
        {
            // Define rasterization options (default settings)
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

            // Configure PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputFile, pngOptions);
        }
    }
}