using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgToPngConversion
{
    static void Main()
    {
        // Prerequisite: valid paths and write permissions
        string inputPath = @"C:\Temp\example.svg";
        string outputPath = @"C:\Temp\example.png";

        // Prerequisite: the SVG file must be accessible via a readable stream
        using (Stream svgStream = File.OpenRead(inputPath))
        // Load the SVG image using the SvgImage constructor that accepts a Stream
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Prerequisite: rasterization options are required to convert vector data to raster
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                // Define the size of the rasterized bitmap; using the original SVG size
                PageSize = svgImage.Size,
                // Optional: set a background color if the SVG contains transparency
                BackgroundColor = Color.White
            };

            // Prerequisite: PNG save options must reference the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG; the output folder must exist and be writable
            svgImage.Save(outputPath, pngOptions);
        }
    }
}