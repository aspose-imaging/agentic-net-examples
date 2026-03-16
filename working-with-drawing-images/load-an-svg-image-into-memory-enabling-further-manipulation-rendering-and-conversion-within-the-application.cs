using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be loaded
        string svgPath = @"C:\temp\example.svg";

        // Load the SVG image from the specified file path
        using (SvgImage svgImage = new SvgImage(svgPath))
        {
            // Ensure all data is cached for fast subsequent operations
            svgImage.CacheData();

            // The SVG image is now fully loaded in memory and can be manipulated,
            // rasterized, or saved in other formats.

            // Example: rasterize the SVG to a PNG file
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            string pngOutputPath = @"C:\temp\example_output.png";

            // Save the rasterized image using the provided Save method
            svgImage.Save(pngOutputPath, pngOptions);
        }
    }
}