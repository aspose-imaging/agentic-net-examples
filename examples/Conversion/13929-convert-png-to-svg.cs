using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToSvgConverter
{
    static void Main()
    {
        // Input PNG file path
        string inputPngPath = @"C:\Temp\input.png";

        // Output SVG file path
        string outputSvgPath = @"C:\Temp\output.svg";

        // Load the PNG image using the unified Image.Load method
        using (Image image = Image.Load(inputPngPath))
        {
            // Prepare rasterization options for SVG conversion.
            // PageSize is set to the original image size to preserve dimensions.
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Create SVG save options and assign the rasterization options.
            SvgOptions svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Optional: set Compress = false to produce plain SVG (not .svgz)
                Compress = false
            };

            // Save the image as SVG using the prepared options.
            image.Save(outputSvgPath, svgSaveOptions);
        }

        Console.WriteLine("Conversion completed: PNG -> SVG");
    }
}