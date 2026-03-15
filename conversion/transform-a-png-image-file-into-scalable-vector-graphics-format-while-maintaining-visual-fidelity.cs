using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class PngToSvgConverter
{
    static void Main()
    {
        // Path to the source PNG file
        string inputPngPath = @"C:\Images\source.png";

        // Desired output SVG file path
        string outputSvgPath = @"C:\Images\converted.svg";

        // Load the PNG image into an Aspose.Imaging.Image object
        using (Image pngImage = Image.Load(inputPngPath))
        {
            // Configure rasterization options – the SVG will have the same page size as the PNG
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = pngImage.Size
            };

            // Create SVG save options and attach the rasterization settings
            var svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the image as SVG while preserving visual fidelity
            pngImage.Save(outputSvgPath, svgSaveOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}