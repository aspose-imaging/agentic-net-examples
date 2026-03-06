using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgToPngConverter
{
    static void Main()
    {
        // Path to the source SVG file
        string inputSvgPath = @"C:\Temp\example.svg";
        // Desired path for the output PNG file
        string outputPngPath = @"C:\Temp\example.png";

        // Open the SVG file as a read‑only stream
        using (Stream svgStream = File.OpenRead(inputSvgPath))
        // Load the SVG image from the stream
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Configure rasterization options for the SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the original SVG dimensions
                PageSize = svgImage.Size
                // Additional options (e.g., background color, scaling) can be set here if needed
            };

            // Create PNG save options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngOptions);
        }

        Console.WriteLine("SVG has been successfully converted to PNG.");
    }
}