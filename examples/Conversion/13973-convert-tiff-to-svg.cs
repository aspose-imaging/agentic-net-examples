using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input TIFF file path
        string inputPath = "input.tif";

        // Output SVG file path
        string outputPath = "output.svg";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG conversion
            var vectorOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Configure SVG save options
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}