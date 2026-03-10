using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class ConvertToSvg
{
    static void Main()
    {
        // Path to the source image (any supported format)
        string inputFile = Path.Combine("C:", "Images", "source.png");
        // Desired output SVG file path
        string outputFile = Path.Combine("C:", "Images", "result.svg");

        // Load the source image using Aspose.Imaging's unified loader
        using (Image image = Image.Load(inputFile))
        {
            // Prepare rasterization options required for SVG conversion
            // PageSize is set to the original image size to preserve dimensions
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Create SVG save options and assign the rasterization options
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Optional: set to true if you want compressed SVGZ output
                // Compress = true,
                // Optional: render all text as shapes
                // TextAsShapes = true
            };

            // Save the image as SVG using the prepared options
            image.Save(outputFile, svgOptions);
        }
    }
}