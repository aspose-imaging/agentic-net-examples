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
        string inputSvgPath = @"C:\Temp\example.svg";
        // Desired path for the output PNG file
        string outputPngPath = @"C:\Temp\example.png";

        // Load the SVG image from the file system using the SvgImage constructor
        using (SvgImage svgImage = new SvgImage(inputSvgPath))
        {
            // Create rasterization options required for converting vector SVG to raster PNG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Set the raster page size to match the original SVG dimensions
                PageSize = svgImage.Size
            };

            // Create PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as a PNG file
            svgImage.Save(outputPngPath, pngOptions);
        }
    }
}