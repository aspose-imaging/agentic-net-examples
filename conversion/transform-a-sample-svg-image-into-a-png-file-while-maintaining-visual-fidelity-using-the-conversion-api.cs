using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;

class SvgToPngConverter
{
    static void Main()
    {
        // Directory containing the SVG file and where the PNG will be saved
        string dir = @"c:\temp\";

        // Full paths for input SVG and output PNG
        string inputSvgPath = Path.Combine(dir, "sample.svg");
        string outputPngPath = Path.Combine(dir, "sample.png");

        // Load the SVG image from a file stream
        using (Stream svgStream = File.OpenRead(inputSvgPath))
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Configure rasterization options – you can set page size, background, etc.
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                // Preserve the original SVG dimensions
                PageSize = svgImage.Size,
                // Optional: set background color if needed
                // BackgroundColor = Color.White
            };

            // Create PNG save options and attach the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as PNG
            svgImage.Save(outputPngPath, pngOptions);
        }

        Console.WriteLine("SVG has been successfully converted to PNG.");
    }
}