using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the source BIGTIFF image
        string inputFile = @"C:\Images\source_big.tiff";

        // Desired output SVG file path
        string outputFile = @"C:\Images\converted.svg";

        // Load the BIGTIFF image using Aspose.Imaging's Image.Load (lifecycle create/load)
        using (Image image = Image.Load(inputFile))
        {
            // Configure rasterization options – page size matches the source image size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up SVG save options with the rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as SVG (lifecycle save)
            image.Save(outputFile, svgOptions);
        }
    }
}