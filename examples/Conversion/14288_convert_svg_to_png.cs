using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Path to the source SVG file
        string inputPath = @"C:\temp\input.svg";
        // Path where the PNG will be saved
        string outputPath = @"C:\temp\output.png";

        // Load the SVG image using Aspose.Imaging's Image.Load (lifecycle rule)
        using (Image image = Image.Load(inputPath))
        {
            // Configure rasterization options – here we keep the original SVG size
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up PNG save options and attach the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG (save rule)
            image.Save(outputPath, pngOptions);
        }
    }
}