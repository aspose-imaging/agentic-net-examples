using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class TiffToSvgConverter
{
    static void Main()
    {
        // Path to the source TIFF file
        string inputFile = @"C:\Images\source.tif";

        // Desired path for the output SVG file
        string outputFile = @"C:\Images\converted.svg";

        // Load the TIFF image using Aspose.Imaging's unified loader
        using (Image tiffImage = Image.Load(inputFile))
        {
            // Configure rasterization options: set the page size to match the source image dimensions
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = tiffImage.Size
            };

            // Create SVG save options and assign the rasterization options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the loaded image as SVG using the configured options
            tiffImage.Save(outputFile, svgOptions);
        }
    }
}