using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class SvgToBmpConverter
{
    // Converts an SVG file to a BMP file.
    // inputSvgPath  - full path to the source SVG file.
    // outputBmpPath - full path where the BMP file will be saved.
    public static void Convert(string inputSvgPath, string outputBmpPath)
    {
        // Load the SVG image using the unified Image.Load method.
        using (Image image = Image.Load(inputSvgPath))
        {
            // Prepare rasterization options required to render vector SVG into a raster bitmap.
            // PageSize is set to the original SVG dimensions to keep the original size.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure BMP save options and attach the rasterization options.
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rendered bitmap as BMP.
            image.Save(outputBmpPath, bmpOptions);
        }
    }

    // Example usage.
    static void Main()
    {
        string svgFile = @"C:\Images\example.svg";
        string bmpFile = @"C:\Images\example.bmp";

        Convert(svgFile, bmpFile);

        Console.WriteLine("Conversion completed.");
    }
}