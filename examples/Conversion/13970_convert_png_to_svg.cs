using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Input PNG file path
        string inputFile = "sample.png";
        // Desired output SVG file path
        string outputFile = "sample.svg";

        // Load the PNG image using Aspose.Imaging
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options for vector conversion
            var rasterOptions = new SvgRasterizationOptions
            {
                // Set the page size to match the source image dimensions
                PageSize = image.Size
            };

            // Create SVG save options and attach the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the loaded PNG image as an SVG file
            image.Save(outputFile, svgOptions);
        }
    }
}