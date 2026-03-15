using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToSvgConverter
{
    static void Main()
    {
        // Path to the source PNG raster image
        string inputPngPath = @"C:\Images\source.png";

        // Desired output SVG file path
        string outputSvgPath = @"C:\Images\converted.svg";

        // Load the PNG image using Aspose.Imaging's generic Image.Load method
        using (Image rasterImage = Image.Load(inputPngPath))
        {
            // Create rasterization options for SVG output.
            // PageSize is set to the original image size to preserve dimensions.
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size
            };

            // Configure SVG save options and attach the rasterization settings.
            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as SVG. The raster content will be embedded
            // within the SVG, maintaining visual fidelity.
            rasterImage.Save(outputSvgPath, svgSaveOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}